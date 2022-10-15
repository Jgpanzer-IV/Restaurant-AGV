namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class QuantityStatus
    {
        public int Id { get; set; }
        public bool IsFinish { get; set; }
        public int PurchasedMenuId { get; set; } 
        public virtual PurchasedMenu? PurchasedMenu { get; set; }
    }
}
