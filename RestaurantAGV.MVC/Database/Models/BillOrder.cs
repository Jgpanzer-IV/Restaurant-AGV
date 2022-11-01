namespace RestaurantAGV.MVC.Models.Entities;

public class BillOrder{
    public int Id {get;set;}
    public DateTime? BillingTime {get;set;}
    public byte? CountingOrder {get;set;}
    public decimal? OrderPrice {get;set;}
    public decimal? VatPrice {get;set;}
    public decimal? Discount {get;set;}
    public decimal? TotalPrice {get;set;}
    public string? BillingSlipUri {get;set;}
    public string CustomerId {get;set;} = string.Empty;
    public virtual Customer? Customer {get;set;}
}