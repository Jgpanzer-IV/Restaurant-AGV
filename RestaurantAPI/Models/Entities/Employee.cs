namespace Restaurant.Service.ServerAPI.Models.Entities
{
    public class Employee
    {
        public string Id { get; set; } = string.Empty;
        public string FistName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RegisterDate { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordId { get; set; } = string.Empty;

        public virtual IList<Phone>? Phones { get; set; }
        public virtual IList<Cook>? Cooks { get; set; }
        public virtual IList<Receiver>? Receivers { get; set; }
    }
}
