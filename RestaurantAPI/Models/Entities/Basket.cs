namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public int CustomerTableId { get; set; }

        public string CustomerId { get; set; } = string.Empty; 
        public virtual CustomerTable? CustomerTable { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual IList<PurchasedMenu>? PurchasedMenus { get; set; }
    }
}
