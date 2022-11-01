namespace RestaurantAGV.MVC.Models.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string UriImage { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public int MenuCategoryId { get; set; }

        public virtual MenuCategory? MenuCategory  { get; set; }
        public virtual IList<SelectedMenu>? SelectedMenus {get;set;}
        public virtual IList<PurchasedMenu>? PurchasedMenus { get; set; }

    }
}
