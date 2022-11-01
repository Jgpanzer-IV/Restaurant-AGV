namespace RestaurantAGV.MVC.Models.Entities
{
    public class Customer
    {
        public string Id { get; set; } = string.Empty;
        public byte CustomerCount { get; set; }
        public DateTime TimeCheckIn { get; set; }
        public DateTime? TimeCheckOut { get; set; }
        public bool BillingDone {get;set; }

        public int TableId {get;set;}

        public virtual IList<PurchasedOrder>? PurchasedOrders { get; set; }
        public virtual BillOrder? BillOrder {get; set;}
        public virtual Basket? Basket { get; set; }
        public virtual Table? Table {get;set;}
    }
}
