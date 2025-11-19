using CondoManager.Entity.Enums;

namespace CondoManager.Entity.Events
{
    public class MessageReceivedEvent
    {
        public int SenderId { get; set; }
        public int? RecipientId { get; set; }
        public int? ConversationId { get; set; }
        public string Content { get; set; } = string.Empty;
        public MessageType MessageType { get; set; }
        public ChatType ChatType { get; set; }
        public DateTime ReceivedAt { get; set; }
        public bool IsAnnouncement { get; set; }
    }

    public class MessageSavedEvent
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int? RecipientId { get; set; }
        public int ConversationId { get; set; }
        public string Content { get; set; } = string.Empty;
        public MessageType MessageType { get; set; }
        public ChatType ChatType { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsAnnouncement { get; set; }
    }

    public class MessageDeliveredEvent
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public DateTime DeliveredAt { get; set; }
    }

    public class MessageReadEvent
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public DateTime ReadAt { get; set; }
    }
}