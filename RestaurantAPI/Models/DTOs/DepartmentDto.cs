namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class DepartmentDto
    {
        public string Id { get; set; } = string.Empty;
        public IList<ReceiverDto>? Receivers { get; set; }
        public IList<CookDto>? Cooks { get; set; }

    
    }
}
