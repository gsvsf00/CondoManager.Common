using CondoManager.Entity.Models;

namespace CondoManager.Repository.Interfaces
{
    public interface ICallParticipantRepository : IRepository<CallParticipant>
    {
        Task<IEnumerable<CallParticipant>> GetByCallIdAsync(int callId);
        Task<CallParticipant?> GetParticipantAsync(int callId, int userId);
        Task<IEnumerable<CallParticipant>> GetActiveParticipantsAsync(int callId);
        Task UpdateParticipantStatusAsync(int callId, int userId, bool isActive);
        Task UpdateParticipantMediaAsync(int callId, int userId, bool isMuted, bool isVideoEnabled);
        Task RemoveParticipantAsync(int callId, int userId);
    }
}