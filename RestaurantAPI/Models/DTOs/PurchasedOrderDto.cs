using System.Security.Cryptography.X509Certificates;

namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class PurchasedOrderDto
    {
        public int Id { get; set; } 
        public string TableName { get; set; } = string.Empty;
        public bool ReceiveAccept { get; set; }
        public bool CustomerAccept { get; set; }
        public bool AllFoodIrderFinished { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchasedTime { get; set; }

        public string ReceiverId { get; set; } = string.Empty;
        public string CookId { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;


        public IList<PurchasedMenuDto>? PurchasedMenus { get; set; }
    }
}
