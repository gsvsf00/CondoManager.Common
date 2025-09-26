using CondoManager.Entity.Models;
using CondoManager.Entity.Enums;

namespace CondoManager.Repository.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        // Legacy methods - can be removed later
        Task<IEnumerable<Message>> GetByApartmentIdAsync(Guid? apartmentId);
        Task<IEnumerable<Message>> GetBySenderIdAsync(Guid senderId);
        Task<IEnumerable<Message>> GetRecentMessagesAsync(Guid apartmentId, int count = 50);
        
        // New conversation-based methods
        Task<IEnumerable<Message>> GetByConversationIdAsync(Guid conversationId, int skip = 0, int take = 50);
        Task<IEnumerable<Message>> GetDirectMessagesAsync(Guid userId1, Guid userId2, int skip = 0, int take = 50);
        Task<Message?> GetMessageWithRepliesAsync(Guid messageId);
        Task<int> GetUnreadCountAsync(Guid userId, Guid conversationId);
        Task MarkAsDeliveredAsync(Guid messageId);
        Task MarkAsReadAsync(Guid messageId, Guid userId);
        Task MarkConversationAsReadAsync(Guid userId, Guid conversationId);
        Task<IEnumerable<Message>> GetUndeliveredMessagesAsync(Guid userId);
        Task<IEnumerable<Message>> GetUnreadMessagesAsync(Guid userId, int count = 10);
        Task<Message?> GetLastMessageByConversationIdAsync(Guid conversationId);
    }
}