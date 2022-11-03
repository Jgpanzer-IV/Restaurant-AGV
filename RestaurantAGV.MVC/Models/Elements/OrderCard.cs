using RestaurantAGV.MVC.Models.Entities;

namespace RestaurantAGV.MVC.Models.Elements;

public class OrderCard{

    public int Id {get;set;}
    public string? PassedTime {get;set;}
    public decimal TotalPrice {get;set;}
    public string? Status {get;set;}
    public string? TableAddress {get;set;}

    public OrderCard(){}

    public OrderCard(PurchasedOrder purchasedOrder){

        TimeSpan orderPassedTime = DateTime.Now.Subtract(purchasedOrder.PurchasedTime);
        
        string timeGetter = string.Empty;
        timeGetter += (orderPassedTime.Hours > 0)? orderPassedTime.Hours+":H ":""; 
        timeGetter += (orderPassedTime.Minutes > 0)? orderPassedTime.Minutes+":M":""; 

        Id = purchasedOrder.Id;
        PassedTime = timeGetter;
        TotalPrice = purchasedOrder.TotalPrice;
        Status = purchasedOrder.Status;
        TableAddress = purchasedOrder.Customer?.TableId.ToString();

    }

}