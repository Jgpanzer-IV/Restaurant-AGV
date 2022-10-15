namespace Restaurant.Service.ServerAPI.Models.DTOs
{
    public class PositionDto
    {
        public string Id { get; set; } = string.Empty;
        public int Salary { get; set; }
        public DateTime WorkinTimeIn { get; set; }
        public DateTime WorkinTimeOut { get; set; }

        public IList<ReceiverDto>? Receivers { get; set; }
        public IList<CookDto>? Cooks { get; set; }
    }
}
