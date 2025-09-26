using CondoManager.Entity.Models;
using CondoManager.Entity.Enums;
using CondoManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Repository.Repositories
{
    public class ConversationRepository : Repository<Conversation>, IConversationRepository
    {
        public ConversationRepository(DbContext context) : base(context)
        {
        }

        public async Task<Conversation?> GetWithParticipantsAsync(Guid conversationId)
        {
            return await _context.Set<Conversation>()
                .Include(c => c.Participants)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(c => c.Id == conversationId);
        }

        public async Task<Conversation?> GetWithMessagesAsync(Guid conversationId, int messageCount = 50)
        {
            return await _context.Set<Conversation>()
                .Include(c => c.Messages.OrderByDescending(m => m.SentAt).Take(messageCount))
                    .ThenInclude(m => m.Sender)
                .Include(c => c.Participants)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(c => c.Id == conversationId);
        }

        public async Task<IEnumerable<Conversation>> GetUserConversationsAsync(Guid userId)
        {
            return await _context.Set<Conversation>()
                .Where(c => c.Participants.Any(p => p.UserId == userId))
                .Include(c => c.Participants)
                    .ThenInclude(p => p.User)
                .OrderByDescending(c => c.LastMessageAt ?? c.CreatedAt)
                .ToListAsync();
        }

        public async Task<Conversation?> GetDirectConversationAsync(Guid userId1, Guid userId2)
        {
            return await _context.Set<Conversation>()
                .Where(c => c.Type == ConversationType.Direct)
                .Where(c => c.Participants.Count == 2 &&
                           c.Participants.Any(p => p.UserId == userId1) &&
                           c.Participants.Any(p => p.UserId == userId2))
                .Include(c => c.Participants)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync();
        }

        public async Task<Conversation?> GetApartmentGroupConversationAsync(Guid apartmentId)
        {
            return await _context.Set<Conversation>()
                .Where(c => c.Type == ConversationType.ApartmentGroup && c.ApartmentId == apartmentId)
                .Include(c => c.Participants)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateLastMessageTimeAsync(Guid conversationId, DateTime lastMessageTime)
        {
            var conversation = await _context.Set<Conversation>()
                .FirstOrDefaultAsync(c => c.Id == conversationId);
            
            if (conversation != null)
            {
                conversation.LastMessageAt = lastMessageTime;
                _context.Set<Conversation>().Update(conversation);
            }
        }

        public async Task<bool> IsUserInConversationAsync(Guid userId, Guid conversationId)
        {
            return await _context.Set<Conversation>()
                .AnyAsync(c => c.Id == conversationId && 
                              c.Participants.Any(p => p.UserId == userId));
        }

        public async Task<IEnumerable<Conversation>> GetConversationsByTypeAsync(ConversationType type)
        {
            return await _context.Set<Conversation>()
                .Where(c => c.Type == type)
                .Include(c => c.Participants)
                    .ThenInclude(p => p.User)
                .OrderByDescending(c => c.LastMessageAt ?? c.CreatedAt)
                .ToListAsync();
        }
    }
}