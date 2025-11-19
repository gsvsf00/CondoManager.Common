using CondoManager.Entity.Enums;

namespace CondoManager.Entity.DTOs
{
    public class CallRequestDto
    {
        public int CallerId { get; set; }
        public int? ApartmentId { get; set; }
        public int? TargetUserId { get; set; }
        public string? Description { get; set; }
    }
}