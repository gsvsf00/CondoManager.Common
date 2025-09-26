using CondoManager.Entity.Enums;

namespace CondoManager.Entity.DTOs
{
    public class ChatMessageDto
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public Guid? ApartmentId { get; set; }
        public string? ApartmentNumber { get; set; }
        public string Content { get; set; } = string.Empty;
        public MessageType MessageType { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}