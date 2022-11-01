using RestaurantAGV.MVC.Models.Entities;

namespace RestaurantAGV.MVC.Models.Admin;


public class CustomerInfoModel{

    public Entities.Customer? Customer {get;set;}
    public Table? Table {get;set;}

    public BillOrder? BillOrder {get;set;}
    public Basket? Basket {get;set;}
    public IList<PurchasedOrder>? PurchasedOrders {get;set;}

}