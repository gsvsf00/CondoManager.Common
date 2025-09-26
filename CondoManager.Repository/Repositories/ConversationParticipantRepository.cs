using CondoManager.Entity.Models;
using CondoManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Repository.Repositories
{
    public class ConversationParticipantRepository : Repository<ConversationParticipant>, IConversationParticipantRepository
    {
        public ConversationParticipantRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ConversationParticipant>> GetByConversationIdAsync(Guid conversationId)
        {
            return await _context.Set<ConversationParticipant>()
                .Where(cp => cp.ConversationId == conversationId)
                .Include(cp => cp.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<ConversationParticipant>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Set<ConversationParticipant>()
                .Where(cp => cp.UserId == userId)
                .Include(cp => cp.Conversation)
                .ToListAsync();
        }

        public async Task<ConversationParticipant?> GetParticipantAsync(Guid conversationId, Guid userId)
        {
            return await _context.Set<ConversationParticipant>()
                .Include(cp => cp.User)
                .Include(cp => cp.Conversation)
                .FirstOrDefaultAsync(cp => cp.ConversationId == conversationId && cp.UserId == userId);
        }

        public async Task<bool> IsUserParticipantAsync(Guid conversationId, Guid userId)
        {
            return await _context.Set<ConversationParticipant>()
                .AnyAsync(cp => cp.ConversationId == conversationId && cp.UserId == userId && cp.IsActive);
        }

        public async Task UpdateLastReadAsync(Guid userId, Guid conversationId, DateTime lastReadAt)
        {
            var participant = await _context.Set<ConversationParticipant>()
                .FirstOrDefaultAsync(cp => cp.ConversationId == conversationId && cp.UserId == userId);
            
            if (participant != null)
            {
                participant.LastReadAt = lastReadAt;
                _context.Set<ConversationParticipant>().Update(participant);
            }
        }

        public async Task RemoveParticipantAsync(Guid conversationId, Guid userId)
        {
            var participant = await _context.Set<ConversationParticipant>()
                .FirstOrDefaultAsync(cp => cp.ConversationId == conversationId && cp.UserId == userId);
            
            if (participant != null)
            {
                _context.Set<ConversationParticipant>().Remove(participant);
            }
        }

        public async Task<IEnumerable<Guid>> GetActiveParticipantIdsAsync(Guid conversationId)
        {
            return await _context.Set<ConversationParticipant>()
                .Where(cp => cp.ConversationId == conversationId)
                .Select(cp => cp.UserId)
                .ToListAsync();
        }
    }
}