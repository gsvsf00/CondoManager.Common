using CondoManager.Entity.Models;
using CondoManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Repository.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Event>> GetUpcomingEventsAsync()
        {
            var now = DateTime.UtcNow;
            return await _dbSet
                .Where(e => e.StartDate > now)
                .Include(e => e.CreatedBy)
                .OrderBy(e => e.StartDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(e => e.StartDate >= startDate && e.EndDate <= endDate)
                .Include(e => e.CreatedBy)
                .OrderBy(e => e.StartDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByCreatorAsync(Guid creatorId)
        {
            return await _dbSet
                .Where(e => e.CreatedById == creatorId)
                .OrderByDescending(e => e.StartDate)
                .ToListAsync();
        }
    }
}