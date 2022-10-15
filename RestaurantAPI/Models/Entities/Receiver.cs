namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class Receiver
    {
        public string Id { get; set; } = string.Empty;
        public string DepartmentId { get; set; } = string.Empty;
        public string PositionId { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;

        public virtual IList<PurchasedOrder>? PurchasedOrders { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Position? Position { get; set; }
        public virtual Department? Department { get; set; }
    }
}
