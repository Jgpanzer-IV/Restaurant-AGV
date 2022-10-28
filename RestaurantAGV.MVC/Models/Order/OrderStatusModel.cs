using RestaurantAGV.MVC.Models.Elements;
namespace RestaurantAGV.MVC.Models.Order;

public class OrderStatusModel{
    public int Id {get;set;}
    public string? TableAddress {get;set;}
    public bool ReceiverStatus {get;set;}
    public bool CustomerStatus {get;set;}
    public bool AllFoodOrderFinished {get;set;}
    public decimal TotalPrice {get;set;}
    public DateTime? PurchasedTime {get;set;}
    public string? Status {get;set;}
    public int Queue {get;set;}
    public IList<MenuStatus>? OrderedMenu {get;set;}

}