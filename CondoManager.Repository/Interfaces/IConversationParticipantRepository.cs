using CondoManager.Entity.Models;

namespace CondoManager.Repository.Interfaces
{
    public interface IConversationParticipantRepository : IRepository<ConversationParticipant>
    {
        Task<IEnumerable<ConversationParticipant>> GetByConversationIdAsync(int conversationId);
        Task<IEnumerable<ConversationParticipant>> GetByUserIdAsync(int userId);
        Task<ConversationParticipant?> GetParticipantAsync(int conversationId, int userId);
        Task<bool> IsUserParticipantAsync(int conversationId, int userId);
        Task UpdateLastReadAsync(int userId, int conversationId, DateTime lastReadAt);
        Task RemoveParticipantAsync(int conversationId, int userId);
        Task<IEnumerable<int>> GetActiveParticipantIdsAsync(int conversationId);
    }
}