using CondoManager.Entity.Models;
using CondoManager.Entity.Enums;

namespace CondoManager.Repository.Interfaces
{
    public interface ICallRepository : IRepository<Call>
    {
        Task<Call?> GetWithParticipantsAsync(int id);
        Task<IEnumerable<Call>> GetActiveCallsAsync();
        Task<IEnumerable<Call>> GetCallsByUserIdAsync(int userId);
        Task<Call?> GetActiveCallByUserIdAsync(int userId);
        Task<IEnumerable<Call>> GetCallHistoryAsync(int userId, int skip = 0, int take = 50);
        Task UpdateCallStatusAsync(int callId, CallStatus status);
        Task UpdateCallDurationAsync(int callId, TimeSpan duration);
        Task<bool> IsUserInActiveCallAsync(int userId);
    }
}