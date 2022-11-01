namespace RestaurantAGV.MVC.Models.Entities
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public virtual IList<Menu>? Menus { get; set; }

    }
}
