using CondoManager.Entity.Models;
using CondoManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Repository.Repositories
{
    public class CallParticipantRepository : Repository<CallParticipant>, ICallParticipantRepository
    {
        public CallParticipantRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CallParticipant>> GetByCallIdAsync(int callId)
        {
            return await _context.Set<CallParticipant>()
                .Where(cp => cp.CallId == callId)
                .Include(cp => cp.User)
                .ToListAsync();
        }

        public async Task<CallParticipant?> GetParticipantAsync(int callId, int userId)
        {
            return await _context.Set<CallParticipant>()
                .Include(cp => cp.User)
                .Include(cp => cp.Call)
                .FirstOrDefaultAsync(cp => cp.CallId == callId && cp.UserId == userId);
        }

        public async Task<IEnumerable<CallParticipant>> GetActiveParticipantsAsync(int callId)
        {
            return await _context.Set<CallParticipant>()
                .Where(cp => cp.CallId == callId && cp.IsActive)
                .Include(cp => cp.User)
                .ToListAsync();
        }

        public async Task UpdateParticipantStatusAsync(int callId, int userId, bool isActive)
        {
            var participant = await _context.Set<CallParticipant>()
                .FirstOrDefaultAsync(cp => cp.CallId == callId && cp.UserId == userId);
            
            if (participant != null)
            {
                participant.IsActive = isActive;
                if (!isActive && participant.LeftAt == null)
                    participant.LeftAt = DateTime.UtcNow;
                
                _context.Set<CallParticipant>().Update(participant);
            }
        }

        public async Task UpdateParticipantMediaAsync(int callId, int userId, bool isMuted, bool isVideoEnabled)
        {
            var participant = await _context.Set<CallParticipant>()
                .FirstOrDefaultAsync(cp => cp.CallId == callId && cp.UserId == userId);
            
            if (participant != null)
            {
                participant.IsMuted = isMuted;
                participant.IsVideoEnabled = isVideoEnabled;
                _context.Set<CallParticipant>().Update(participant);
            }
        }

        public async Task RemoveParticipantAsync(int callId, int userId)
        {
            var participant = await _context.Set<CallParticipant>()
                .FirstOrDefaultAsync(cp => cp.CallId == callId && cp.UserId == userId);
            
            if (participant != null)
            {
                _context.Set<CallParticipant>().Remove(participant);
            }
        }
    }
}