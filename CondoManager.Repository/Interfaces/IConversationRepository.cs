using CondoManager.Entity.Models;
using CondoManager.Entity.Enums;

namespace CondoManager.Repository.Interfaces
{
    public interface IConversationRepository : IRepository<Conversation>
    {
        Task<Conversation?> GetWithParticipantsAsync(Guid conversationId);
        Task<Conversation?> GetWithMessagesAsync(Guid conversationId, int messageCount = 50);
        Task<IEnumerable<Conversation>> GetUserConversationsAsync(Guid userId);
        Task<Conversation?> GetDirectConversationAsync(Guid userId1, Guid userId2);
        Task<Conversation?> GetApartmentGroupConversationAsync(Guid apartmentId);
        Task<IEnumerable<Conversation>> GetConversationsByTypeAsync(ConversationType type);
        Task UpdateLastMessageTimeAsync(Guid conversationId, DateTime lastMessageTime);
        Task<bool> IsUserInConversationAsync(Guid userId, Guid conversationId);
    }
}