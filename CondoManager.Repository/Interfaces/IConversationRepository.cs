using CondoManager.Entity.Models;
using CondoManager.Entity.Enums;

namespace CondoManager.Repository.Interfaces
{
    public interface IConversationRepository : IRepository<Conversation>
    {
        Task<Conversation?> GetWithParticipantsAsync(int conversationId);
        Task<Conversation?> GetWithMessagesAsync(int conversationId, int messageCount = 50);
        Task<IEnumerable<Conversation>> GetUserConversationsAsync(int userId);
        Task<Conversation?> GetDirectConversationAsync(int userId1, int userId2);
        Task<Conversation?> GetApartmentGroupConversationAsync(int apartmentId);
        Task<IEnumerable<Conversation>> GetConversationsByTypeAsync(ConversationType type);
        Task UpdateLastMessageTimeAsync(int conversationId, DateTime lastMessageTime);
        Task<bool> IsUserInConversationAsync(int userId, int conversationId);
    }
}