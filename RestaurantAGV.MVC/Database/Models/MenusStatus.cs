namespace RestaurantAGV.MVC.Models.Entities
{
    public class MenusStatus
    {
        public int Id { get; set; }
        public bool IsFinish { get; set; }
        public int PurchasedMenuId { get; set; } 
        public virtual PurchasedMenu? PurchasedMenu { get; set; }
    }
}
