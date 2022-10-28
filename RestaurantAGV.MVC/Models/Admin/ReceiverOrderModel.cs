using RestaurantAGV.MVC.Models.Elements;


namespace RestaurantAGV.MVC.Models.Admin;

public class ReceiverOrderModel{
    public IList<OrderCard>? WaitingOrder {get;set;}
    public IList<OrderCard>? ProcessingOrder {get;set;}
    public IList<OrderCard>? FinishOrder {get;set;}
    public IList<OrderCard>? DeniedOrder {get;set;}

}