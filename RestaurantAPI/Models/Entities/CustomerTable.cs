namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class CustomerTable
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty; 
        public string NumberTable { get; set; } = string.Empty;
        public bool IsReserved { get; set; }
        public virtual IList<Basket>? Baskets { get; set; }
    }
}
