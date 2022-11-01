namespace RestaurantAGV.MVC.Models.Entities
{
    public class Cook
    {
        public string Id { get; set; } = string.Empty;

        public string DepartmentId { get; set; }= string.Empty;
        public string PositionId { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;


        public virtual IList<PurchasedMenu>? PurchasedMenu { get; set; }

        public virtual Position? Position { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Employee? Employee { get; set; }

    }
}
