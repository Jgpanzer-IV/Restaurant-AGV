using Microsoft.AspNetCore.Mvc;
using RestaurantAGV.MVC.Models.Admin;
using RestaurantAGV.MVC.Models.Elements;
using RestaurantAGV.MVC.Constants;
using Microsoft.AspNetCore.Authorization;
using RestaurantAGV.MVC.Services.Interfaces;
using System.Linq;
using RestaurantAGV.MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace RestaurantAGV.MVC.Controllers;

[Authorize("AdminPolicy")]
public class AdminController : Controller{

    private readonly ITableRepository _tabelRepo; 
    private readonly ICustomerRepository _customerRepo;
    private readonly IBasketRepository _basketRepo;
    private readonly IBillingOrderRepository _billRepo;
    private readonly IPublisherMQTT _publisherMqtt;

    public AdminController(
        ITableRepository tableRepository,
        ICustomerRepository customerRepository,
        IPublisherMQTT publisherMQTT, 
        IBasketRepository basketRepository,
        IBillingOrderRepository billingOrderRepository)
    {
        _tabelRepo = tableRepository;
        _customerRepo = customerRepository;
        _basketRepo = basketRepository;
        _billRepo = billingOrderRepository;
        _publisherMqtt = publisherMQTT;

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
    public ViewResult AGVStatus(string agvId,string routeTable){

        AGVStatusModel entity = new AGVStatusModel(){
            AGVsStatus = new List<AGVCard>(){
                new(){
                    Id = 64,
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
                    Id = 15,
                    Battery = 45.1f,
                    CodeName = "Alpha8Q",
                    IsAvaliable = false
                }

            }
        };

        if (!string.IsNullOrEmpty(agvId)){
            _publisherMqtt.PublishAsync("myTopic"," Id : "+agvId +" : "+ routeTable);
        }


        return View(entity);
    }

    [HttpGet]
    public async Task<ViewResult> ReserveTable(string section,string filler){

        ReserveTableModel tables = new();
        tables.Tables = new List<TableCard>();
        tables.AddressList = new List<SelectListItem>();

        IList<Table>? retrieved = await _tabelRepo.RetrieveAsync();

        if (retrieved != null){
            retrieved.ToList().ForEach(e => {
                tables.AddressList.Add(new SelectListItem(e.Address,e.Address));
            });
            // Filler here
            if(!string.IsNullOrEmpty(section))
            {
                retrieved = retrieved.Where(e => e.Address == section).ToList();
            }

            if (filler == "Reserved"){
                retrieved.Where(e => e.IsReserved == true).ToList().ForEach(e => {
                    tables.Tables.Add(new TableCard(e));
                });
            
            }else if (filler == "Reservable"){
                retrieved.Where(e => !e.IsReserved).ToList().ForEach(e => {
                    tables.Tables.Add(new TableCard(e));
                });

            }else if (filler == "Recently"){
                Customer? recentCustomer = (await _customerRepo.RetrieveAsync())?.OrderByDescending(e => e.TimeCheckIn).FirstOrDefault();
                if(recentCustomer != null){
                    Table? table = retrieved.FirstOrDefault(e => e.Id == recentCustomer.TableId);
                    if (table != null)
                        tables.Tables.Add(new TableCard(table)); 
                }
            }else{
                retrieved.ToList().ForEach(e => {
                    tables.Tables.Add(new TableCard(e));
                });
            }

        }

        


        return View(tables);
    }

    [HttpGet]
    public async Task<RedirectToActionResult> RegisterCustomer(int tableId, byte customerNumber){

        // Retrieve reserved table 
        Table? table = await _tabelRepo.RetrieveByIdAsync(tableId);
        // If it null then return to the reserve table page
        if (table == null)
            return RedirectToAction(nameof(ReserveTable));

        char[] alphabet = new char[]{'A','B','C','D','F','G'};
        Random random = new Random();
        
        StringBuilder credencialCode = new();

        while(true){
           
            // generate customer Id
            for (byte i=0; i<4; i++){
                credencialCode.Append(alphabet[random.Next(0,alphabet.Length)]);
            }
            
            // Check for repeatitive of customer Id
            if (await _customerRepo.RetrieveByIdAsync(credencialCode.ToString()) == null)
                break;
        }


        // Create new customer object
        Customer newCustomer = new(){
            Id = credencialCode.ToString(),
            TimeCheckIn = DateTime.Now,
            BillingDone = false,
            CustomerCount = customerNumber,
            TableId = tableId,
            Basket = new(){CustomerId = credencialCode.ToString()},
            BillOrder = new(){CustomerId = credencialCode.ToString()}
        };

        // Create Customer and related entity.
        // If it fail to create then redirect back to the reserve table page
        if (await _customerRepo.CreateAsync(newCustomer) == null) 
            return RedirectToAction(nameof(ReserveTable));

        // Update table status
        if(table != null){
            table.IsReserved = true;
            if (await _tabelRepo.UpdateAsync(table) == null)
                return RedirectToAction(nameof(ReserveTable));

        }


        return RedirectToAction(nameof(CustomerInfo), new{customerId = credencialCode});
    }

    [HttpGet]
    public async Task<IActionResult> CustomerInfo(string customerId){
        
        CustomerInfoModel customerInfoModel = new();
        Customer? customer = await _customerRepo.RetrieveByIdAsync(customerId);

        if (customer != null){
            customerInfoModel.Customer = customer;
            customerInfoModel.Table = customer.Table;
            customerInfoModel.BillOrder = customer.BillOrder;
            customerInfoModel.Basket = customer.Basket;
            customerInfoModel.PurchasedOrders = customer.PurchasedOrders;
        }

        return View(customerInfoModel);
    }
}