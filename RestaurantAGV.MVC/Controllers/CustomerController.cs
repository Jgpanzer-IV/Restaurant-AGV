using RestaurantAGV.MVC.Models.Elements;
using Microsoft.AspNetCore.Mvc;
using RestaurantAGV.MVC.Models.Customer;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantAGV.MVC.Controllers;

[Authorize("CustomerPolicy")]
public class CustomerController : Controller{


    [HttpGet]
    public ViewResult Menu(){

        IList<MenuCard> listMenu = new List<MenuCard>(){
            new MenuCard(){
                Id = 1,
                Title = "American Shrimp",
                Description = "Description about the menu describing a detail of the meterial that used to make this menu.",
                Src = "/images/american-shrimp-fried-rice.jpg",
                Price = 24.ToString("C")
            },
            new MenuCard(){
                Id = 2,
                Title = "Froed Pork Garlic",
                Description = "Description about the menu describing a detail of the meterial that used to make this menu.",
                Src = "/images/fried-pork-with-garlic-pepper.jpg",
                Price = 32.ToString("C")
            },
            new MenuCard(){
                Id = 3,
                Title = "Fired Spring rolls",
                Description = "Description about the menu describing a detail of the meterial that used to make this menu.",
                Src = "/images/fried-spring-rolls.jpg",
                Price = 40.ToString("C")
            }
        };

        return View(listMenu);
    }

    [HttpGet]
    public ViewResult MenuDetail(int id){

        MenuDetailModel selectedMenu = new(){
            Id = id,
            NameMenu = "American Shrimp Fried",
            Price = 57.20M,
            Description = "Food is any substance consumed to provide nutritional support for an organism. Food is usually of plant, animal, or fungal origin, and contains essential nutrients, such as carbohydrates, fats, proteins, vitamins, or minerals.",
            UriImage = "/images/american-shrimp-fried-rice.jpg"

        };

        return View(selectedMenu);
    }

    [HttpGet]
    public ViewResult Basket(){

        BasketModel basketModel = new BasketModel(){
            TotalPrice = 142.98M,
            SelectedMenu = new List<MenuStatus>(){
                new(){
                    NameMenu = "American Shrimp Fried",
                    Quantity = 3,
                    Category = "Sea Food",
                    Finish = 0,
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
                    Finish = 0,
                    TotalPrice = 24.5M,
                    UriImage = "/images/thai-food-som-tum-papaya-salad.jpg"

                },
                new(){
                    NameMenu = "Fired Spring Roll",
                    Quantity = 1,
                    Category = "Food",
                    Finish = 0,
                    TotalPrice = 12.66M,
                    UriImage = "/images/fried-spring-rolls.jpg"

                }
            }
        };

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