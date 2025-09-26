using CondoManager.Entity.Models;

namespace CondoManager.Repository.Interfaces
{
    public interface IConversationParticipantRepository : IRepository<ConversationParticipant>
    {
        Task<IEnumerable<ConversationParticipant>> GetByConversationIdAsync(Guid conversationId);
        Task<IEnumerable<ConversationParticipant>> GetByUserIdAsync(Guid userId);
        Task<ConversationParticipant?> GetParticipantAsync(Guid conversationId, Guid userId);
        Task<bool> IsUserParticipantAsync(Guid conversationId, Guid userId);
        Task UpdateLastReadAsync(Guid userId, Guid conversationId, DateTime lastReadAt);
        Task RemoveParticipantAsync(Guid conversationId, Guid userId);
        Task<IEnumerable<Guid>> GetActiveParticipantIdsAsync(Guid conversationId);
    }
}