using CondoManager.Entity.Models;
using CondoManager.Entity.Enums;

namespace CondoManager.Repository.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        // Legacy methods - can be removed later
        Task<IEnumerable<Message>> GetByApartmentIdAsync(int? apartmentId);
        Task<IEnumerable<Message>> GetBySenderIdAsync(int senderId);
        Task<IEnumerable<Message>> GetRecentMessagesAsync(int apartmentId, int count = 50);
        
        // New conversation-based methods
        Task<IEnumerable<Message>> GetByConversationIdAsync(int conversationId, int skip = 0, int take = 50);
        Task<IEnumerable<Message>> GetDirectMessagesAsync(int userId1, int userId2, int skip = 0, int take = 50);
        Task<Message?> GetMessageWithRepliesAsync(int messageId);
        Task<int> GetUnreadCountAsync(int userId, int conversationId);
        Task MarkAsDeliveredAsync(int messageId);
        Task MarkAsReadAsync(int messageId, int userId);
        Task MarkConversationAsReadAsync(int userId, int conversationId);
        Task<IEnumerable<Message>> GetUndeliveredMessagesAsync(int userId);
        Task<IEnumerable<Message>> GetUnreadMessagesAsync(int userId, int count = 10);
        Task<Message?> GetLastMessageByConversationIdAsync(int conversationId);
    }
}