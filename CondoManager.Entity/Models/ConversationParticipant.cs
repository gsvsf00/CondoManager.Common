namespace CondoManager.Entity.Models
{
    public class ConversationParticipant
    {
        public int Id { get; set; }
        
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; } = null!;
        
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        
        public DateTime JoinedAt { get; set; }
        public DateTime? LeftAt { get; set; }
        
        public bool IsActive { get; set; } = true;
        public bool IsAdmin { get; set; } = false; // For group chat admins
        
        public DateTime? LastReadAt { get; set; } // For read receipts
    }
}