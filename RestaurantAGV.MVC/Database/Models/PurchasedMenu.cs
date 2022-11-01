namespace RestaurantAGV.MVC.Models.Entities
{
    public class PurchasedMenu
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; } = string.Empty;
        public bool IsFinish { get; set; }

        public int BasketId { get; set; }
        public int MenuNameId { get; set; }
        public int PurchasedOrderId { get; set; }
        public string? CookId {get;set;}
         
        public virtual Basket? Basket { get; set; }
        public virtual Menu? Menu { get; set; }
        public virtual PurchasedOrder? PurchasedOrder { get; set; }
        public virtual Cook? Cook {get;set;}
        public virtual IList<MenusStatus>? MenusStatus { get; set; }


    }
}
