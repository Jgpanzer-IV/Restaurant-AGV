namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class CustomerDto
    {
        public string CredencialCode { get; set; } = string.Empty;
        public byte CustomerCount { get; set; }
        public DateTime TimeCheckIn { get; set; }
        public DateTime? TimeCheckOut { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDone { get; set; }

        public IList<PurchasedOrderDto>? PurchasedOrders { get; set; }
        public BasketDto? Basket { get; set; }
    }
}
