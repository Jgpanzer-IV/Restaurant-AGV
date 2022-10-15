namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class ReceiverDto
    {
        public string Id { get; set; } = string.Empty;  
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int EmployeeId { get; set; } 

        public IList<PurchasedOrderDto>? PurchasedOrders { get; set; }
    }
}
