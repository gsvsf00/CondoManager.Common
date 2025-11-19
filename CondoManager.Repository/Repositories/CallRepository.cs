using CondoManager.Entity.Models;
using CondoManager.Entity.Enums;
using CondoManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Repository.Repositories
{
    public class CallRepository : Repository<Call>, ICallRepository
    {
        public CallRepository(DbContext context) : base(context)
        {
        }

        public async Task<Call?> GetWithParticipantsAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Participants)
                    .ThenInclude(p => p.User)
                .Include(c => c.Caller)
                .Include(c => c.Recipient)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Call>> GetCallsByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(c => c.CallerId == userId || c.RecipientId == userId)
                .Include(c => c.Caller)
                .Include(c => c.Recipient)
                .OrderByDescending(c => c.StartedAt)
                .ToListAsync();
        }

        public async Task UpdateCallStatusAsync(int callId, CallStatus status)
        {
            var call = await _dbSet.FindAsync(callId);
            if (call != null)
            {
                call.Status = status;
                if (status == CallStatus.Connected && !call.ConnectedAt.HasValue)
                {
                    call.ConnectedAt = DateTime.UtcNow;
                }
                else if (status == CallStatus.Ended && !call.EndedAt.HasValue)
                {
                    call.EndedAt = DateTime.UtcNow;
                    if (call.ConnectedAt.HasValue)
                    {
                        call.Duration = call.EndedAt.Value - call.ConnectedAt.Value;
                    }
                }
                _context.Set<Call>().Update(call);
            }
        }

        public async Task<IEnumerable<Call>> GetActiveCallsAsync()
        {
            return await _dbSet
                .Where(c => c.Status == CallStatus.Ringing || c.Status == CallStatus.Connected)
                .Include(c => c.Participants)
                .Include(c => c.Caller)
                .Include(c => c.Recipient)
                .ToListAsync();
        }

        public async Task<Call?> GetActiveCallByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(c => (c.CallerId == userId || c.Participants.Any(p => p.UserId == userId)) &&
                           (c.Status == CallStatus.Ringing || c.Status == CallStatus.Connected))
                .Include(c => c.Participants)
                .Include(c => c.Caller)
                .Include(c => c.Recipient)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Call>> GetCallHistoryAsync(int userId, int skip = 0, int take = 50)
        {
            return await _dbSet
                .Where(c => c.CallerId == userId || c.Participants.Any(p => p.UserId == userId))
                .Include(c => c.Participants)
                .Include(c => c.Caller)
                .Include(c => c.Recipient)
                .OrderByDescending(c => c.StartedAt)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task UpdateCallDurationAsync(int callId, TimeSpan duration)
        {
            var call = await _dbSet.FindAsync(callId);
            if (call != null)
            {
                call.Duration = duration;
                _context.Set<Call>().Update(call);
            }
        }

        public async Task<bool> IsUserInActiveCallAsync(int userId)
        {
            return await _dbSet
                .AnyAsync(c => (c.CallerId == userId || c.Participants.Any(p => p.UserId == userId)) &&
                              (c.Status == CallStatus.Ringing || c.Status == CallStatus.Connected));
        }
    }
}