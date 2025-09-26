using CondoManager.Entity.Enums;

namespace CondoManager.Entity.Models
{
    public class Conversation
    {
        public Guid Id { get; set; }
        
        public ConversationType Type { get; set; }
        
        public string? Name { get; set; } // For group chats or custom names
        
        public Guid? ApartmentId { get; set; } // For apartment-related conversations
        public Apartment? Apartment { get; set; }
        
        public Guid? CreatedByUserId { get; set; } // Who created this conversation
        public User? CreatedByUser { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime? LastMessageAt { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<ConversationParticipant> Participants { get; set; } = new List<ConversationParticipant>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}