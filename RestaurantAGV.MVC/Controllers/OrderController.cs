
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Models.Elements;
using RestaurantAGV.MVC.Models.Order;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Constants;

namespace RestaurantAGV.MVC.Controllers;

[Authorize]
public class OrderController : Controller{


    private readonly IPurchasedOrderRepository _purchasedOrderRepo;
    private readonly ITableRepository _tableRepo;
    private readonly IMenuRepository _menuRepo;
    private readonly IMenuCategoryRepository _menuCategoryRepo;
    private readonly IMenusStatusRepository _menuStatusRepo;
    private readonly IPurchasedMenuRepository _purchasedMenuRepo;


    public OrderController(
        IPurchasedOrderRepository purchasedOrder,
        ITableRepository tableRepository,
        IMenuRepository menuRepository,
        IMenusStatusRepository menusStatusRepository,
        IMenuCategoryRepository menuCategoryRepo,
        IPurchasedMenuRepository purchasedMenuRepository
        )
    {
        _purchasedOrderRepo = purchasedOrder;
        _tableRepo = tableRepository;
        _menuRepo = menuRepository;
        _menuStatusRepo = menusStatusRepository;
        _menuCategoryRepo = menuCategoryRepo;
        _purchasedMenuRepo = purchasedMenuRepository;
    }

    [HttpGet]
    public async Task<IActionResult> OrderStatus(int orderId){

        // Purchased order entity.
        PurchasedOrder? purchasedOrder = await _purchasedOrderRepo.RetrieveByIdAsync(orderId);
        
        // Check for purcagse entity 
        if (purchasedOrder == null){
            ViewData["ViewData"] = "There is no OrderStatus entity with the specified OrderId.";
            return View(new OrderStatusModel());
        }

        // Retrieve table entity that being used by the user
        Table? table = await _tableRepo.RetrieveByIdAsync(purchasedOrder.Customer?.TableId ?? 0);

        OrderStatusModel orderStatusModel = new(){
            Id = purchasedOrder.Id,
            TableAddress =  table?.NumberTable + table?.Address,
            ReceiverStatus = purchasedOrder.ReceiverStatus,
            CustomerStatus = purchasedOrder.CustomerStatus,
            AllFoodOrderFinished = purchasedOrder.IsAllFinish,
            PurchasedTime = purchasedOrder.PurchasedTime,
            Status = purchasedOrder.Status,
            TotalPrice = purchasedOrder.TotalPrice,
            Queue = purchasedOrder.Queue,
            OrderedMenu = new List<MenuStatus>()
        };

        IList<Menu>? menus = await _menuRepo.RetrieveAsync();
        IList<MenuCategory>? categoryMenu = await _menuCategoryRepo.RetrieveAsync();
        List<MenusStatus>? menuStatuses = (await _menuStatusRepo.RetrieveAsync())?.ToList();

        purchasedOrder.PurchasedMenus?.ToList().ForEach((e) => {
            orderStatusModel.OrderedMenu.Add(new MenuStatus(){
                id = e.Id,
                NameMenu = menus?.First(menu => menu.Id == e.MenuNameId).MenuName ?? string.Empty,
                Quantity = (byte) e.Quantity,
                Finish = (byte) (menuStatuses?.Where(a => a.PurchasedMenuId == e.Id).Where(f => f.IsFinish == true).Count() ?? 0),
                Category = categoryMenu?.First(a => a.Id == menus?.First(menu => menu.Id == e.MenuNameId).MenuCategoryId).CategoryName ?? string.Empty,
                TotalPrice = e.Quantity * menus?.First(menu => menu.Id == e.MenuNameId).Price ?? 0,
                UriImage = menus?.First(menu => menu.Id == e.MenuNameId).UriImage ?? ""
            });
        });
        

        return View(orderStatusModel);
    }


    [HttpGet]
    public async Task<IActionResult> UpdateOrderStatus(int id,string role){

        // Update entity here for both side
        PurchasedOrder? purchasedOrder = await _purchasedOrderRepo.RetrieveByIdAsync(id);

        if (purchasedOrder == null){
            ViewData["problem"] = "Cannot retrieve the purchased order entity, Plase contect admin.";
        }else{

            if (role == RoleConst.CustomerRole){
                // update value for Customer's accept status
                purchasedOrder.CustomerStatus = true;

            }else if (role == RoleConst.StuffRole || role == RoleConst.AdminRole){
                // update value for Receiver's accept status
                purchasedOrder.ReceiverStatus = true;

            }

            if (await _purchasedOrderRepo.UpdateAsync(purchasedOrder) == null){
                ViewData["problem"] = "Cannot update the status of the entity, Please contact the admin.";
            }
        }

        return RedirectToAction(nameof(OrderStatus), new {orderId = id});
    }
    

    [HttpPost]
    public async Task<IActionResult> UpdateMenuStatus(int orderId, int purchasedMenuId, int additionalFinish){

        
        IList<MenusStatus>? menusStatus = (await _menuStatusRepo.RetrieveAsync())?.Where(e => e.PurchasedMenuId == purchasedMenuId).ToList();  

        if (menusStatus == null)
            return RedirectToAction(nameof(OrderStatus));

        int updatedEntity = 0;
        foreach(MenusStatus each in menusStatus){
            if (!each.IsFinish && updatedEntity < additionalFinish){
                // Update finish status for the MenuStatus that based on the purchasedMenuId 
                each.IsFinish = true;
                if(await _menuStatusRepo.UpdateAsync(each) == null)
                    ViewData["problem"] = "Cannot update the menu status"; 
                else
                    updatedEntity++;
            }
        }

        PurchasedMenu? purchasedMenu = await _purchasedMenuRepo.RetrieveByIdAsync(purchasedMenuId);
        if(purchasedMenu == null){
            ViewData["problem"] = "Cannot retrieve the purchasedMenu, Please context admin.";
            return RedirectToAction(nameof(OrderStatus), new {orderId = orderId});
        }
            

        if (await _purchasedMenuRepo.UpdateAsync(purchasedMenu) == null)
            ViewData["problem"] = "Cannot update the purchasedMenu entity, Please context admin.";

        return RedirectToAction(nameof(OrderStatus), new {orderId = orderId});
    }

}