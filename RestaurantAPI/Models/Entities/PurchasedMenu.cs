namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class PurchasedMenu
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string Note { get; set; } = string.Empty;

        public bool IsPurchased { get; set; }
        public int BasketId { get; set; }
        public int MenuNameId { get; set; }

        public int? PurchasedOrderId { get; set; }
         
        public virtual IList<QuantityStatus>? QuantityStatuses { get; set; }
        public virtual Basket? Basket { get; set; }
        public virtual Menu? Menu { get; set; }
        public virtual PurchasedOrder? PurchasedOrder { get; set; }


    }
}
