using Microsoft.AspNetCore.Mvc;
using RestaurantAGV.MVC.Models.Admin;
using RestaurantAGV.MVC.Models.Elements;
using RestaurantAGV.MVC.Constants;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantAGV.MVC.Controllers;

[Authorize("AdminPolicy")]
public class AdminController : Controller{

    public AdminController()
    {
        
    }

    [HttpGet]
    public ViewResult ReceiverOrder(){

        ReceiverOrderModel retrievedEntity = new(){
            WaitingOrder = new List<OrderCard>(){
                new(){
                    Id = 4,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,20,0)).Minutes.ToString(),
                    Status = EntityConstants.OrderWaiting,
                    TableAddress ="InRoom 08",
                    TotalPrice = 41M
                },
                  new(){
                    Id = 5,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,20,0)).Minutes.ToString(),
                    Status = EntityConstants.OrderWaiting,
                    TableAddress ="InRoom 08",
                    TotalPrice = 44M
                },
                  new(){
                    Id = 6,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,20,0)).Minutes.ToString(),
                    Status = EntityConstants.OrderWaiting,
                    TableAddress ="InRoom 08",
                    TotalPrice = 41M
                },
            },
            ProcessingOrder = new List<OrderCard>(){
                 new(){
                    Id = 14,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,20,0)).Minutes.ToString(),
                    Status = EntityConstants.OrderProcessing,
                    TableAddress ="InRoom 10",
                    TotalPrice = 94M
                }
            },
            FinishOrder = new List<OrderCard>(){
                new(){
                    Id = 14,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,20,0)).Minutes.ToString(),
                    Status = EntityConstants.OrderFinish,
                    TableAddress ="InRoom 10",
                    TotalPrice = 12.1M
                },
                new(){
                    Id = 19,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,20,0)).Minutes.ToString(),
                    Status = EntityConstants.OrderFinish,
                    TableAddress ="InRoom 19",
                    TotalPrice = 94M
                },new(){
                    Id = 20,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,20,0)).Minutes.ToString(),
                    Status = EntityConstants.OrderFinish,
                    TableAddress ="InRoom 14",
                    TotalPrice = 94M
                },
                new(){
                    Id = 21,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,20,0)).Minutes.ToString(),
                    Status = EntityConstants.OrderFinish,
                    TableAddress ="InRoom 15",
                    TotalPrice = 94M
                }
            },
            DeniedOrder = new List<OrderCard>(){
                new(){
                    Id = 11,
                    PassedTime = DateTime.Now.Subtract(new DateTime(2022,10,27,17,20,0)).Minutes.ToString(),
                    Status = EntityConstants.OrderDenied,
                    TableAddress ="InRoom 15",
                    TotalPrice = 94M
                }
            }

        };

        return View(retrievedEntity);
    }


    [HttpGet]
    public ViewResult AGVStatus(){

        AGVStatusModel entity = new AGVStatusModel(){
            AGVsStatus = new List<AGVCard>(){
                new(){
                    Id = 485,
                    Battery = 42.1f,
                    CodeName = "Alpha7Q",
                    IsAvaliable = true
                },
                 new(){
                    Id = 42,
                    Battery = 97.1f,
                    CodeName = "Alpha4Q",
                    IsAvaliable = true
                },
                 new(){
                    Id = 485,
                    Battery = 12.2f,
                    CodeName = "Alpha2Q",
                    IsAvaliable = true
                },
                 new(){
                    Id = 485,
                    Battery = 45.1f,
                    CodeName = "Alpha8Q",
                    IsAvaliable = false
                }

            }
        };


        return View(entity);
    }


    [HttpGet]
    public ViewResult ReserveTable(){

        ReserveTableModel tables = new(){
            Tables = new List<TableCard>{
                new(){
                    Id = 1,
                    TableNumber = "01",
                    Address = "In Room",
                    ChairCount = 4
                },
                new(){
                    Id = 2,
                    TableNumber = "02",
                    Address = "In Room",
                    ChairCount = 4
                },
                new(){
                    Id = 3,
                    TableNumber = "01",
                    Address = "Out Door",
                    ChairCount = 6
                },
                new(){
                    Id = 4,
                    TableNumber = "02",
                    Address = "Out Door",
                    ChairCount = 4
                },
                new(){
                    Id = 5,
                    TableNumber = "01",
                    Address = "VIP",
                    ChairCount = 8
                },
                new(){
                    TableNumber = "02",
                    Address = "VIP",
                    ChairCount = 12
                }
                
            }
             
        };

        return View(tables);
    }

}