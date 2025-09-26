namespace CondoManager.Entity.DTOs
{
    public class ApartmentDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}