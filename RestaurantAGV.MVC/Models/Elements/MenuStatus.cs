
namespace RestaurantAGV.MVC.Models.Elements;

public class MenuStatus{

    public int? id {get;set;}
    public string NameMenu {get;set;} = string.Empty;
    public string Category {get;set;} = string.Empty;
    public decimal TotalPrice {get;set;}
    public byte Quantity {get;set;}
    public byte Finish {get;set;} 
    public string UriImage {get;set;} = string.Empty;

}