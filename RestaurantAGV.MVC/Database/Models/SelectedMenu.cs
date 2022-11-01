namespace RestaurantAGV.MVC.Models.Entities;


public class SelectedMenu{

    public int Id {get;set;}
    public int Quantity {get;set;}
    public string? Note {get;set;}

    public int BasketId {get;set;}
    public int MenuId {get;set;}
    public virtual Basket? Basket {get;set;}
    public virtual Menu? Menu {get;set;}

}