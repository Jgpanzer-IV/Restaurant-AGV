namespace RestaurantAGV.MVC.Models.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty; 
        public string NumberTable { get; set; } = string.Empty;
        public byte ChairQuantity {get;set;}
        public int DistantMeter {get;set;}
        public bool IsReserved { get; set; }

        public virtual IList<Customer>? Customers { get; set; }
    }
}
