namespace CondoManager.Entity.Models
{
    public class CallParticipant
    {
        public Guid Id { get; set; }
        
        public Guid CallId { get; set; }
        public Call Call { get; set; } = null!;
        
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        
        public DateTime JoinedAt { get; set; }
        public DateTime? LeftAt { get; set; }
        
        public bool IsActive { get; set; } = true;
        public bool IsMuted { get; set; } = false;
        public bool IsVideoEnabled { get; set; } = true;
    }
}