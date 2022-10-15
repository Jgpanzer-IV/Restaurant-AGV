namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public string NameCategory { get; set; } = string.Empty;

        public virtual IList<Menu>? Menus { get; set; }

    }
}
