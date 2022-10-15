namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class MenuCategoryDto
    {
        public int Id { get; set; }
        public string NameCategory { get; set; } = string.Empty;

        public IList<MenuDto>? Menus { get; set; }
    }
}
