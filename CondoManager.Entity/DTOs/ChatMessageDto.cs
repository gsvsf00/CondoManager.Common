using CondoManager.Entity.Enums;

namespace CondoManager.Entity.DTOs
{
    public class ChatMessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public int? ApartmentId { get; set; }
        public string? ApartmentNumber { get; set; }
        public string Content { get; set; } = string.Empty;
        public MessageType MessageType { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}