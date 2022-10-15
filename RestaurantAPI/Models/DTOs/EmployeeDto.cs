namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class EmployeeDto
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime RegerDate { get; set; }
        public string Email { get; set; } = string.Empty ;
        public string Password { get; set; } = string.Empty;

        public IList<CookDto>? Cooks { get; set; }
        public IList<ReceiverDto>? Receivers { get; set; }
        public IList<PhoneDto>? Phones { get; set; }


    }
}
