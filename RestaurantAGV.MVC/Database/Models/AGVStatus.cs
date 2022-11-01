namespace RestaurantAGV.MVC.Models.Entities
{
    public class AGVStatus
    {
        public int Id { get; set; }
        public string CodeName { get; set; } = string.Empty;
        public float? Battery { get; set; }
        public bool IsAvaliable { get; set; }
    }
}
