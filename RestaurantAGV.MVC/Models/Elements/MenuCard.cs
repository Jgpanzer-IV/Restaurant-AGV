using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Models.Elements;

public class MenuCard{

    public int Id {get;set;}
    public string Title {get;set;} = string.Empty;
    public string Description {get;set;} = string.Empty;
    public string Src {get;set;} = string.Empty;
    public string Price {get;set;} = string.Empty;

    public MenuCard(){}

    public MenuCard(Menu menu){
        Id = menu.Id;
        Title = menu.MenuName;
        Description = menu.Description;
        Src = menu.UriImage;
        Price = menu.Price.ToString("C");
    }

}