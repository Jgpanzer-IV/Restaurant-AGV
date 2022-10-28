using RestaurantAGV.MVC.Models.Elements;

namespace RestaurantAGV.MVC.Models.Customer;

public class BasketModel{

    public decimal TotalPrice {get;set;}
    public IList<MenuStatus>? SelectedMenu {get;set;}

}