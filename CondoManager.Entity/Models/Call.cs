using CondoManager.Entity.Enums;

namespace CondoManager.Entity.Models
{
    public class Call
    {
        public int Id { get; set; }
        
        public int CallerId { get; set; }
        public User Caller { get; set; } = null!;
        
        public int? RecipientId { get; set; } // Null for group calls
        public User? Recipient { get; set; }
        
        public int? ConversationId { get; set; } // For group calls
        public Conversation? Conversation { get; set; }
        
        public CallType Type { get; set; }
        public CallStatus Status { get; set; }
        
        public DateTime StartedAt { get; set; }
        public DateTime? ConnectedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        
        public TimeSpan? Duration { get; set; }
        
        public string? EndReason { get; set; } // "completed", "declined", "missed", "failed"
        
        // For group calls
        public ICollection<CallParticipant> Participants { get; set; } = new List<CallParticipant>();
    }
}