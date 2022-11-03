using RestaurantAGV.MVC.Models.Elements;
using Microsoft.AspNetCore.Mvc;
using RestaurantAGV.MVC.Models.Customer;
using Microsoft.AspNetCore.Authorization;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Constants;

namespace RestaurantAGV.MVC.Controllers;

[Authorize("CustomerPolicy")]
public class CustomerController : Controller{

    private readonly IMenuCategoryRepository _menuCategoryRepo;
    private readonly IMenuRepository _menuRepo;
    private readonly ISelectedMenuRepository _selectedMenuRepo;
    private readonly IBasketRepository _basketRepo;
    private readonly IPurchasedMenuRepository _purchasedMenuRepo;
    private readonly IPurchasedOrderRepository _purchasedOrderRepo;
    private readonly IMenusStatusRepository _menuStatusRepo;
    private readonly ICustomerRepository _customerRepo;
    

    public CustomerController(
        IMenuCategoryRepository menuRepository,
        IMenuRepository menuRepo,
        ISelectedMenuRepository selectedMenuRepository,
        IBasketRepository basketRepository,
        IPurchasedMenuRepository purchasedMenuRepository,
        IPurchasedOrderRepository purchasedOrderRepo,
        IMenusStatusRepository menusStatusRepository,
        ICustomerRepository customerRepository
        )
    {
        _menuCategoryRepo = menuRepository;
        _menuRepo = menuRepo;
        _selectedMenuRepo = selectedMenuRepository;
        _basketRepo = basketRepository;
        _purchasedMenuRepo = purchasedMenuRepository;
        _purchasedOrderRepo = purchasedOrderRepo; 
        _menuStatusRepo = menusStatusRepository;
        _customerRepo = customerRepository;
    }

    [HttpGet]
    public async Task<ViewResult> Menu(string type = "food"){

        IList<MenuCategory>? listMenu =  await _menuCategoryRepo.RetrieveAsync();
        IList<MenuCard> cardMenus = new List<MenuCard>();

        if(listMenu == null)
            return View(cardMenus);

        if (type == "food"){
            listMenu.Where(e => e.Id != 6 && e.Id != 7).ToList().ForEach(e => {
                e.Menus?.ToList().ForEach(menu => {
                    cardMenus.Add(new MenuCard(menu));
                });
            });
        }
        else if (type == "drink"){
            listMenu.Where(e => e.Id == 7).ToList().ForEach(e => {
                e.Menus?.ToList().ForEach(menu => {
                    cardMenus.Add(new MenuCard(menu));
                });
            });

        }else if (type == "dessert"){
            listMenu.Where(e => e.Id == 6).ToList().ForEach(e => {
                e.Menus?.ToList().ForEach(menu => {
                    cardMenus.Add(new MenuCard(menu));
                });
            });
        }

        return View(cardMenus);
    }

    [HttpGet]
    public async Task<ViewResult> MenuDetail(int id){

        Menu? RetrievedMenu = await _menuRepo.RetrieveByIdAsync(id);
        MenuDetailModel selectedMenu = new();

        if(RetrievedMenu != null){
            selectedMenu = new(){
                Id = RetrievedMenu.Id,
                NameMenu =  RetrievedMenu.MenuName,
                Price =  RetrievedMenu.Price,
                Description = RetrievedMenu.Description,
                UriImage = RetrievedMenu.UriImage
            };
        }

        return View(selectedMenu);
    }

    [HttpGet]
    public async Task<RedirectToActionResult> OrderMenu(string note, int quantity, int menuId){

        // Retrieve information about the purchaser
        string? baskId = HttpContext.User.Claims.ToList().FirstOrDefault(e => e.Type == ClaimConstants.BasketClaimId)?.Value;

        // Create Selected menu for the user that have clicked the purchase button.
        SelectedMenu selectedMenu = new(){
            BasketId = Convert.ToInt32(baskId),
            MenuId = menuId,
            Quantity = quantity,
            Note = note
        };

        // Create new selectedMenu in the database
        if (await _selectedMenuRepo.CreateAsync(selectedMenu) == null)
            return RedirectToAction(nameof(MenuDetail));

        return RedirectToAction(nameof(Basket));
    }

    [HttpGet]
    public async Task<IActionResult> Basket(){

        int basketId = Convert.ToInt32(HttpContext.User.Claims.ToArray().FirstOrDefault(e => e.Type == ClaimConstants.BasketClaimId)?.Value);
        
        // Retrieve basket entity using basketId
        RestaurantAGV.MVC.Models.Entities.Basket? basket = await _basketRepo.RetrieveByIdAsync(basketId);

        // Check if it is null, Then the might be an error 
        if(basket == null)
            return RedirectToAction(nameof(MenuDetail));
    
        // Create enetity for view
        BasketModel basketModel = new BasketModel();
        basketModel.SelectedMenu = new List<MenuStatus>();

        // loop to each selectedMenu entity that inside the basket 
        for (int i=0; i<basket.SelectedMenus?.Count(); i++){

            Menu? menu = await _menuRepo.RetrieveByIdAsync(basket.SelectedMenus.ElementAt(i).MenuId);

            basketModel.SelectedMenu.Add(new MenuStatus(){
                NameMenu = menu?.MenuName ?? "",
                Category = menu?.MenuCategory?.CategoryName ?? "",
                Finish = 0,
                Quantity = (byte) basket.SelectedMenus.ElementAt(i).Quantity,
                TotalPrice = menu?.Price * basket.SelectedMenus.ElementAt(i).Quantity ?? 0,
                UriImage = menu?.UriImage ?? ""             
            });
        }


        // Set the total price by sum of total price in each selectedMenu entity
        basketModel.TotalPrice = basketModel.SelectedMenu.Sum(e => e.TotalPrice);

        return View(basketModel);
    }


    [HttpGet]
    public async Task<IActionResult> PurchaseMenu(){

        // Retrieve Claim information
        int basketId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimConstants.BasketClaimId)?.Value ?? "0");
        string customerId = HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimConstants.CustomerClaimId)?.Value ?? ""; 

        // Retrieve basket and related entity
        Basket? basket = await _basketRepo.RetrieveByIdAsync(basketId);
        IList<Menu>? menus = await _menuRepo.RetrieveAsync();

        // Check for resulting
        if (basket == null || menus == null){
            ViewData["problem"] = "An error have accoured while retriving basket entity";
            return RedirectToAction(nameof(Basket));
        }

        int RegisteredQueue = (await _purchasedOrderRepo.RetrieveAsync())?.Where(e => e.Status == EntityConstants.OrderWaiting || e.Status == EntityConstants.OrderProcessing).Count() ?? 0;
        decimal totalPrice = 0;

        for (byte i=0; i < basket.SelectedMenus?.Count(); i++){
            totalPrice += menus.First(e => e.Id == basket.SelectedMenus?.ElementAt(i).MenuId).Price * basket.SelectedMenus?.ElementAt(i).Quantity ?? 0;
        }

        // Create Purchased Order
        PurchasedOrder? purchasedOrder = await _purchasedOrderRepo.CreateAsync(new PurchasedOrder(){
            CustomerId = customerId,
            ReceiverStatus = false,
            CustomerStatus = false,
            IsAllFinish = false,
            TotalPrice = totalPrice,
            PurchasedTime = DateTime.Now,
            Status = EntityConstants.OrderWaiting,
            Queue = RegisteredQueue+1
        });
        
        if (purchasedOrder == null){
            ViewData["problem"] = "An error have accoured while creating entity";
            return RedirectToAction(nameof(Basket));
        }
        
        PurchasedMenu? purchasedMenuGetter;

        for(int i=0 ;i<basket.SelectedMenus?.Count(); i++){

            // Create PurchasedMenu based on the SelectedMenu
            purchasedMenuGetter = await _purchasedMenuRepo.CreateAsync(new PurchasedMenu(){
                BasketId = basketId,
                PurchasedOrderId = purchasedOrder.Id,
                MenuNameId = basket.SelectedMenus.ElementAt(i).MenuId,
                Quantity = basket.SelectedMenus.ElementAt(i).Quantity,
                Note = basket.SelectedMenus.ElementAt(i).Note ?? string.Empty,
                IsFinish = false,
            });

            for (byte q=0; q < purchasedMenuGetter?.Quantity; q++){
                await _menuStatusRepo.CreateAsync(new MenusStatus(){
                    PurchasedMenuId = purchasedMenuGetter.Id,
                    IsFinish = false,
                });
            }

            // Delete SelectedMenu entities base on this basket
            await _selectedMenuRepo.DeleteAsync(basket.SelectedMenus.ElementAt(i).Id);
        }
        

        return RedirectToAction("OrderStatus","Order",new {orderId = purchasedOrder.Id});
    }


    [HttpGet]
    public async Task<ViewResult> Billing(){

        string customerId = HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimConstants.CustomerClaimId)?.Value ?? string.Empty;
        IList<PurchasedOrder>? purchasedOrders = (await _purchasedOrderRepo.RetrieveAsync())?.Where(e => e.CustomerId == customerId).ToList();
        Customer? customer = await _customerRepo.RetrieveByIdAsync(customerId);

        if (customer?.BillingDone ?? false)
            return View();

        decimal totalOrderPrice = purchasedOrders?.Sum(e => e.TotalPrice) ?? 0; 
        decimal vatPrice = (totalOrderPrice * EntityConstants.VatPercentage) / 100;

        BillingModel billingModel = new(){
            Discount = customer?.CustomerCount * 0.8M ?? 0M,
            OrderPrice = totalOrderPrice,
            OrderCount = (byte) (purchasedOrders?.Count() ?? 0),
            VatPrice = vatPrice,
            TotalPrice =  totalOrderPrice + vatPrice,
            BillingTime = DateTime.Now,
            OrderedOrders = new List<OrderCard>()
        };
        purchasedOrders?.ToList().ForEach(e => {
            billingModel.OrderedOrders.Add(new OrderCard(e));
        });

        return View(billingModel);
    }
    
    [HttpPost]
    public IActionResult Billing(string answer){


        return RedirectToAction("Menu");
    }

}