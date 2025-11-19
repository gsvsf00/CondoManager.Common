namespace CondoManager.Entity.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;
    }
}
