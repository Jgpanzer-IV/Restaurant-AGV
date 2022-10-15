namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class Customer
    {
        public string CredencialCode { get; set; } = string.Empty;
        public byte CustomerCount { get; set; }
        public DateTime TimeCheckIn { get; set; }
        public DateTime? TimeCheckOut { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDone { get; set; }

        public virtual IList<PurchasedOrder>? PurchasedOrders { get; set; }
        public virtual IList<Basket>? Baskets { get; set; }

    }
}
