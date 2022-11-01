namespace RestaurantAGV.MVC.Models.Entities
{
    public class PurchasedOrder
    {
        public int Id { get; set; }
        public bool ReceiverStatus { get; set; }
        public bool CustomerStatus { get; set; }
        public bool IsAllFinish { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchasedTime { get; set; }
        public string Status {get;set;} = string.Empty;
        public int Queue {get;set;}

        public string? ReceiverId { get; set; }
        public string CustomerId { get; set; } = string.Empty;

        public virtual Receiver? Receiver { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual IList<PurchasedMenu>? PurchasedMenus { get; set; }


    }
}
