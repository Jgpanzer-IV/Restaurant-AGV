namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class BasketDto
    {
        public int Id { get; set; }
        public int CustomerTableId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public IList<PurchasedMenuDto>? PurchasedMenus { get; set; }
    }
}
