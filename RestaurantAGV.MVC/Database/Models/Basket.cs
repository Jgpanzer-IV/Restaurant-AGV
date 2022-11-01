namespace RestaurantAGV.MVC.Models.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        
        public virtual Customer? Customer { get; set; }
        public virtual IList<SelectedMenu>? SelectedMenus {get;set;}
        public virtual IList<PurchasedMenu>? PurchasedMenus { get; set; }
    }
}
