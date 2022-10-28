using RestaurantAGV.MVC.Models.Elements;

namespace RestaurantAGV.MVC.Models.Customer;

public class BillingModel{
    public DateTime? BillingTime{get;set;}
    public byte OrderCount {get;set;}
    public decimal OrderPrice {get;set;}
    public decimal VatPrice {get;set;}
    public decimal Discount {get;set;}
    public decimal TotalPrice {get;set;}

    public IList<OrderCard>? OrderedOrders {get;set;}
}