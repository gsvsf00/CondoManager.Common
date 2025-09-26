using CondoManager.Entity.Models;

namespace CondoManager.Repository.Interfaces
{
    public interface ICallParticipantRepository : IRepository<CallParticipant>
    {
        Task<IEnumerable<CallParticipant>> GetByCallIdAsync(Guid callId);
        Task<CallParticipant?> GetParticipantAsync(Guid callId, Guid userId);
        Task<IEnumerable<CallParticipant>> GetActiveParticipantsAsync(Guid callId);
        Task UpdateParticipantStatusAsync(Guid callId, Guid userId, bool isActive);
        Task UpdateParticipantMediaAsync(Guid callId, Guid userId, bool isMuted, bool isVideoEnabled);
        Task RemoveParticipantAsync(Guid callId, Guid userId);
    }
}