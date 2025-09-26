using CondoManager.Entity.Models;
using CondoManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Repository.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Message>> GetByApartmentIdAsync(Guid? apartmentId)
        {
            return await _dbSet
                .Where(m => m.ApartmentId == apartmentId)
                .Include(m => m.Sender)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetBySenderIdAsync(Guid senderId)
        {
            return await _dbSet
                .Where(m => m.SenderId == senderId)
                .Include(m => m.Apartment)
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetRecentMessagesAsync(Guid apartmentId, int count = 50)
        {
            return await _dbSet
                .Where(m => m.ApartmentId == apartmentId)
                .Include(m => m.Sender)
                .OrderByDescending(m => m.SentAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetByConversationIdAsync(Guid conversationId, int skip = 0, int take = 50)
        {
            return await _dbSet
                .Where(m => m.ConversationId == conversationId)
                .Include(m => m.Sender)
                .Include(m => m.ReplyToMessage)
                .OrderBy(m => m.SentAt)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetDirectMessagesAsync(Guid userId1, Guid userId2, int skip = 0, int take = 50)
        {
            return await _dbSet
                .Where(m => (m.SenderId == userId1 && m.RecipientId == userId2) ||
                           (m.SenderId == userId2 && m.RecipientId == userId1))
                .Include(m => m.Sender)
                .OrderBy(m => m.SentAt)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<Message?> GetMessageWithRepliesAsync(Guid messageId)
        {
            return await _dbSet
                .Include(m => m.Sender)
                .Include(m => m.ReplyToMessage)
                    .ThenInclude(r => r.Sender)
                .FirstOrDefaultAsync(m => m.Id == messageId);
        }

        public async Task<int> GetUnreadCountAsync(Guid userId, Guid conversationId)
        {
            return await _dbSet
                .CountAsync(m => m.ConversationId == conversationId && 
                                m.SenderId != userId && 
                                !m.IsRead);
        }

        public async Task MarkAsDeliveredAsync(Guid messageId)
        {
            var message = await _dbSet.FirstOrDefaultAsync(m => m.Id == messageId);
            if (message != null)
            {
                message.DeliveredAt = DateTime.UtcNow;
                message.IsDelivered = true;
                _context.Set<Message>().Update(message);
            }
        }

        public async Task MarkAsReadAsync(Guid messageId, Guid userId)
        {
            var message = await _dbSet.FirstOrDefaultAsync(m => m.Id == messageId);
            
            if (message != null && !message.IsRead)
            {
                message.ReadAt = DateTime.UtcNow;
                message.IsRead = true;
                _context.Set<Message>().Update(message);
            }
        }

        public async Task MarkConversationAsReadAsync(Guid userId, Guid conversationId)
        {
            var messages = await _dbSet
                .Where(m => m.ConversationId == conversationId && 
                           m.SenderId != userId && 
                           !m.IsRead)
                .ToListAsync();

            foreach (var message in messages)
            {
                message.ReadAt = DateTime.UtcNow;
                message.IsRead = true;
            }

            if (messages.Any())
            {
                _context.Set<Message>().UpdateRange(messages);
            }
        }

        public async Task<IEnumerable<Message>> GetUndeliveredMessagesAsync(Guid userId)
        {
            return await _dbSet
                .Where(m => m.RecipientId == userId && m.DeliveredAt == null)
                .Include(m => m.Sender)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetUnreadMessagesAsync(Guid userId, int count = 10)
        {
            return await _dbSet
                .Where(m => m.RecipientId == userId && !m.IsRead)
                .Include(m => m.Sender)
                .OrderByDescending(m => m.SentAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Message?> GetLastMessageByConversationIdAsync(Guid conversationId)
        {
            return await _dbSet
                .Where(m => m.ConversationId == conversationId)
                .Include(m => m.Sender)
                .OrderByDescending(m => m.SentAt)
                .FirstOrDefaultAsync();
        }
    }
}