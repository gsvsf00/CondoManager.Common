using CondoManager.Entity.Enums;

namespace CondoManager.Entity.DTOs
{
    public class CallRequestDto
    {
        public Guid CallerId { get; set; }
        public Guid? ApartmentId { get; set; }
        public Guid? TargetUserId { get; set; }
        public string? Description { get; set; }
    }
}