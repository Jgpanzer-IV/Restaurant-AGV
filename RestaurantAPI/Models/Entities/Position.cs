namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class Position
    {
        public string Id { get; set; } = string.Empty;
        public int Salary { get; set; }
        public DateTime WorkingTimeIn { get; set; }
        public DateTime WorkingTimeOut { get; set; }

        public virtual IList<Cook>? Cooks { get; set; }
        public virtual IList<Receiver>? Receivers { get; set; }
    }
}
