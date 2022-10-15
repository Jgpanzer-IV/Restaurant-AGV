namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class CustomerTableDto
    {
       public int Id { get; set; }
        
        public string NumberTable { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string IsReserved { get; set; } = string.Empty;

        public IList<BasketDto>? Baskets { get; set; }
    }
}
