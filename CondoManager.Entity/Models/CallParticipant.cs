namespace CondoManager.Entity.Models
{
    public class CallParticipant
    {
        public int Id { get; set; }
        
        public int CallId { get; set; }
        public Call Call { get; set; } = null!;
        
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        
        public DateTime JoinedAt { get; set; }
        public DateTime? LeftAt { get; set; }
        
        public bool IsActive { get; set; } = true;
        public bool IsMuted { get; set; } = false;
        public bool IsVideoEnabled { get; set; } = true;
    }
}