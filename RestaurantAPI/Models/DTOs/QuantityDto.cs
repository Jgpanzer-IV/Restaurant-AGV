namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class QuantityDto
    {
        public int Id { get; set; }
        public int PurchasedMenuId {get;set;} 
        public bool IsFinish { get;set; }
    }
}
