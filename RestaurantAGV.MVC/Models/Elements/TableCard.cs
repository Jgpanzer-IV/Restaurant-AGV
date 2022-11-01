

using RestaurantAGV.MVC.Models.Entities;

namespace RestaurantAGV.MVC.Models.Elements;

public class TableCard{
    public int Id {get;set;}
    public string? TableNumber {get;set;}
    public string? Address {get;set;}
    public byte ChairCount {get;set;}

    public TableCard(){}

    public TableCard(Table table){
        Id = table.Id;
        TableNumber = table.NumberTable;
        Address = table.Address;
        ChairCount = table.ChairQuantity;

    }

}