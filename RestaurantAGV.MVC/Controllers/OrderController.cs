
using Microsoft.AspNetCore.Mvc;
using RestaurantAGV.MVC.Models.Elements;
using RestaurantAGV.MVC.Models.Order;

namespace RestaurantAGV.MVC.Controllers;

public class OrderController : Controller{

    public OrderController()
    {
        
    }

    [HttpGet]
    public IActionResult OrderStatus(){

        OrderStatusModel orderStatusModel = new(){
            Id = 73,
            TableAddress = "InRoom 8",
            ReceiverStatus = true,
            CustomerStatus = false,
            AllFoodOrderFinished = false,
            PurchasedTime = DateTime.Now,
            Status = "In progress",
            TotalPrice = 130.45M,
            Queue = 6,
            OrderedMenu = new List<MenuStatus>(){
                new(){
                    NameMenu = "American Shrimp Fried",
                    Quantity = 3,
                    Category = "Sea Food",
                    Finish = 2,
                    TotalPrice = 72.66M,
                    UriImage = "/images/american-shrimp-fried-rice.jpg"
                },
                new(){
                    NameMenu = "Fired Pork Garlic",
                    Quantity = 1,
                    Category = "Food",
                    Finish = 0,
                    TotalPrice = 14.2M,
                    UriImage = "/images/fried-pork-with-garlic-pepper.jpg"
                },new(){
                    NameMenu = "SomTum Papaya",
                    Quantity = 2,
                    Category = "Food",
                    Finish = 1,
                    TotalPrice = 24.5M,
                    UriImage = "/images/thai-food-som-tum-papaya-salad.jpg"

                },
                new(){
                    NameMenu = "Fired Spring Roll",
                    Quantity = 1,
                    Category = "Food",
                    Finish = 1,
                    TotalPrice = 12.66M,
                    UriImage = "/images/fried-spring-rolls.jpg"

                }
            }
        };

        return View(orderStatusModel);
    }

    
    

}