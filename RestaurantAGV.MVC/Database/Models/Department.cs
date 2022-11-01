namespace RestaurantAGV.MVC.Models.Entities
{
    public class Department
    {
        public string Id { get; set; } = string.Empty;
        public virtual IList<Cook>? Cooks { get; set; }
        public virtual IList<Receiver>? Receivers { get; set; }
    }
}
