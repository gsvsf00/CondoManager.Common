using CondoManager.Entity.Enums;

namespace CondoManager.Entity.Models
{
    public class CallSession
    {
        public Guid Id { get; set; }

        public Guid CallerId { get; set; }
        public User Caller { get; set; } = null!;

        public Guid? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }

        public ICollection<CallParticipant> Participants { get; set; } = new List<CallParticipant>();

        public CallStatus Status { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime? EndedAt { get; set; }
    }
}
