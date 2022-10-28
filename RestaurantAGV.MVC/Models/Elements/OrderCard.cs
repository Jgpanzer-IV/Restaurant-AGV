namespace RestaurantAGV.MVC.Models.Elements;

public class OrderCard{

    public int Id {get;set;}
    public string? PassedTime {get;set;}
    public decimal TotalPrice {get;set;}
    public string? Status {get;set;}
    public string? TableAddress {get;set;}

}