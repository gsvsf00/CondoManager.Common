using CondoManager.Entity.Enums;

namespace CondoManager.Entity.DTOs
{
    public class CallResponseDto
    {
        public Guid Id { get; set; }
        public Guid CallerId { get; set; }
        public string CallerName { get; set; } = string.Empty;
        public Guid? ApartmentId { get; set; }
        public string? ApartmentNumber { get; set; }
        public CallStatus Status { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public string? Description { get; set; }
        public List<CallParticipantDto> Participants { get; set; } = new();
    }

    public class CallParticipantDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime JoinedAt { get; set; }
        public DateTime? LeftAt { get; set; }
    }
}