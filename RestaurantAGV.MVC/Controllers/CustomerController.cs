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


    public CustomerController(
        IMenuCategoryRepository menuRepository,
        IMenuRepository menuRepo,
        ISelectedMenuRepository selectedMenuRepository,
        IBasketRepository basketRepository
        )
    {
        _menuCategoryRepo = menuRepository;
        _menuRepo = menuRepo;
        _selectedMenuRepo = selectedMenuRepository;
        _basketRepo = basketRepository;
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
        RestaurantAGV.MVC.Models.Entities.Basket? retrieved = await _basketRepo.RetrieveByIdAsync(basketId);

        // Check if it is null, Then the might be an error 
        if(retrieved == null)
            return RedirectToAction(nameof(MenuDetail));
    
        // Create enetity for view
        BasketModel basketModel = new BasketModel();
        basketModel.SelectedMenu = new List<MenuStatus>();

        // loop to each selectedMenu entity that inside the basket 
        for (int i=0; i<retrieved.SelectedMenus?.Count(); i++){

            Menu? menu = await _menuRepo.RetrieveByIdAsync(retrieved.SelectedMenus.ElementAt(i).MenuId);

            basketModel.SelectedMenu.Add(new MenuStatus(){
                NameMenu = menu?.MenuName ?? "",
                Category = menu?.MenuCategory?.CategoryName ?? "",
                Finish = 0,
                Quantity = (byte) retrieved.SelectedMenus.ElementAt(i).Quantity,
                TotalPrice = menu?.Price * retrieved.SelectedMenus.ElementAt(i).Quantity ?? 0,
                UriImage = menu?.UriImage ?? ""             
            });
        }


        // Set the total price by sum of total price in each selectedMenu entity
        basketModel.TotalPrice = basketModel.SelectedMenu.Sum(e => e.TotalPrice);

        return View(basketModel);
    }

    [HttpGet]
    public ViewResult Billing(){
        
        BillingModel billingModel = new(){
            Discount = 3.12M,
            OrderPrice = 133.12M,
            OrderCount = 6,
            VatPrice = 17M,
            TotalPrice = 147M,
            BillingTime = DateTime.Now,
            OrderedOrders = new List<OrderCard>(){
                new(){
                    Id = 4,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,20,0)).Minutes.ToString(),
                    Status = "Finished",
                    TableAddress ="InRoom 08",
                    TotalPrice = 41M
                },
                new(){
                    Id = 6,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,22,0)).Minutes.ToString(),
                    Status = "Finished",
                    TableAddress ="InRoom 08",
                    TotalPrice = 59M
                },
                new(){
                    Id = 14,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,25,0)).Minutes.ToString(),
                    Status = "Finished",
                    TableAddress ="InRoom 08",
                    TotalPrice = 23.15M
                }
            }
        };
        return View(billingModel);
    }
    
    [HttpPost]
    public IActionResult Billing(string answer){


        return RedirectToAction("Menu");
    }

}