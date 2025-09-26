using CondoManager.Entity.Enums;

namespace CondoManager.Entity.Events
{
    public class MessageReceivedEvent
    {
        public Guid SenderId { get; set; }
        public Guid? RecipientId { get; set; }
        public Guid? ConversationId { get; set; }
        public string Content { get; set; } = string.Empty;
        public MessageType MessageType { get; set; }
        public ChatType ChatType { get; set; }
        public DateTime ReceivedAt { get; set; }
        public bool IsAnnouncement { get; set; }
    }

    public class MessageSavedEvent
    {
        public Guid MessageId { get; set; }
        public Guid SenderId { get; set; }
        public Guid? RecipientId { get; set; }
        public Guid ConversationId { get; set; }
        public string Content { get; set; } = string.Empty;
        public MessageType MessageType { get; set; }
        public ChatType ChatType { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsAnnouncement { get; set; }
    }

    public class MessageDeliveredEvent
    {
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DeliveredAt { get; set; }
    }

    public class MessageReadEvent
    {
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ReadAt { get; set; }
    }
}