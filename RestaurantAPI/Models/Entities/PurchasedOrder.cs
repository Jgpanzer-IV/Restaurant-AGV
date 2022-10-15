namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class PurchasedOrder
    {
        public int Id { get; set; }

        public string TableName { get; set; } = string.Empty;
        
        public bool ReceiveAccept { get; set; }

        public bool CustomerAccept { get; set; }

        public bool AllFoodOrderFinished { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime PurchasedTime { get; set; }

        public string? ReceiverId { get; set; } = string.Empty;
        public string? CookId { get; set; } = string.Empty;

        public string CredencialCode { get; set; } = string.Empty;
        public virtual Receiver? Receiver { get; set; }
        public virtual Cook? Cook { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual IList<PurchasedMenu>? PurchasedMenus { get; set; }


    }
}
