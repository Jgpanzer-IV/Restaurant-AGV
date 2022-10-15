namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class PurchasedMenuDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; } = string.Empty;
        public bool IsPurchased { get; set; }

        public int BasketId { get; set; }
        public int MenuNameId { get; set; }
        public int OrderId { get; set; }

        public IList<QuantityDto>? Quantities { get; set; }

    }
}
