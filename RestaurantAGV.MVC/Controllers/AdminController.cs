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
    private readonly IPurchasedOrderRepository _purchasedOrder;

    public AdminController(
        ITableRepository tableRepository,
        ICustomerRepository customerRepository,
        IPublisherMQTT publisherMQTT, 
        IBasketRepository basketRepository,
        IBillingOrderRepository billingOrderRepository,
        IPurchasedOrderRepository purchasedOrderRepository)
    {
        _tabelRepo = tableRepository;
        _customerRepo = customerRepository;
        _basketRepo = basketRepository;
        _billRepo = billingOrderRepository;
        _publisherMqtt = publisherMQTT;
        _purchasedOrder = purchasedOrderRepository;
    }

    [HttpGet]
    public async Task<ViewResult> ReceiverOrder(){

        ReceiverOrderModel receiverOrderModel = new();
        receiverOrderModel.WaitingOrder = new List<OrderCard>();
        receiverOrderModel.DeniedOrder = new List<OrderCard>();
        receiverOrderModel.FinishOrder = new List<OrderCard>();
        receiverOrderModel.ProcessingOrder = new List<OrderCard>();

        IList<PurchasedOrder>? purchasedOrders = await _purchasedOrder.RetrieveAsync();

        purchasedOrders?.ToList().ForEach(e => {
            if (e.Status == EntityConstants.OrderWaiting){
                receiverOrderModel.WaitingOrder.Add(new OrderCard(e));
            }else if (e.Status == EntityConstants.OrderProcessing){
                receiverOrderModel.ProcessingOrder.Add(new OrderCard(e));
            }else if (e.Status == EntityConstants.OrderDenied){
                receiverOrderModel.DeniedOrder.Add(new OrderCard(e));
            }else{
                receiverOrderModel.FinishOrder.Add(new OrderCard(e));
            }
        });

        return View(receiverOrderModel);
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
        
        // Instanciate the object that needed to be sent to view
        ReserveTableModel tables = new();
        tables.Tables = new List<TableCard>();
        tables.AddressList = new List<SelectListItem>();

        // Retrieve all entities of table entity
        IList<Table>? retrieved = await _tabelRepo.RetrieveAsync();

        if (retrieved != null){
            
            retrieved.DistinctBy(e => e.Address).ToList().ForEach(e => {
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