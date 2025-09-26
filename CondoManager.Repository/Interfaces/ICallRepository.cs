using CondoManager.Entity.Models;
using CondoManager.Entity.Enums;

namespace CondoManager.Repository.Interfaces
{
    public interface ICallRepository : IRepository<Call>
    {
        Task<Call?> GetWithParticipantsAsync(Guid id);
        Task<IEnumerable<Call>> GetActiveCallsAsync();
        Task<IEnumerable<Call>> GetCallsByUserIdAsync(Guid userId);
        Task<Call?> GetActiveCallByUserIdAsync(Guid userId);
        Task<IEnumerable<Call>> GetCallHistoryAsync(Guid userId, int skip = 0, int take = 50);
        Task UpdateCallStatusAsync(Guid callId, CallStatus status);
        Task UpdateCallDurationAsync(Guid callId, TimeSpan duration);
        Task<bool> IsUserInActiveCallAsync(Guid userId);
    }
}