namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class CookDto
    {
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int EmployeeId { get; set; }
        public IList<PurchasedOrderDto>? PurchasedOrders { get; set; }
    }
}
