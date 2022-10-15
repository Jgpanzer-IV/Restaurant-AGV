namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class Phone
    {
        public string PhoneNumber { get; set; } = string.Empty;

        public string EmployeeId { get; set; } = string.Empty;
        public virtual Employee? Employee { get; set; }

    }
}
