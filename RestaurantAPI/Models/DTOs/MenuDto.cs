namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string NameMenu { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string UriImage { get; set; } = string.Empty;    
        public string Description { get; set; } = string.Empty;
        
        public int MenuCategoryId { get; set; }
    }
}
