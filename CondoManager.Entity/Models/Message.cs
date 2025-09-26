using CondoManager.Entity.Enums;

namespace CondoManager.Entity.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }
        public User Sender { get; set; } = null!;

        // New conversation-based approach
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; } = null!;

        // For direct messages (optional - can be derived from conversation)
        public Guid? RecipientId { get; set; }
        public User? Recipient { get; set; }

        // Legacy support - can be removed later
        public Guid? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }

        public ChatType ChatType { get; set; }
        public MessageType Type { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime SentAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime? ReadAt { get; set; }
        
        public bool IsDelivered { get; set; } = false;
        public bool IsRead { get; set; } = false;
        public bool IsEdited { get; set; } = false;
        public DateTime? EditedAt { get; set; }
        
        // For announcement messages
        public bool IsAnnouncement { get; set; } = false;
        
        // For reply functionality
        public Guid? ReplyToMessageId { get; set; }
        public Message? ReplyToMessage { get; set; }
    }
}
