using CondoManager.Entity.Models;
using CondoManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Repository.Repositories
{
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(DbContext context) : base(context)
        {
        }

        public async Task<Apartment?> GetWithResidentsAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Residents)
                    .ThenInclude(au => au.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Apartment?> GetByNumberAsync(string number)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Number == number);
        }

        public async Task<IEnumerable<Apartment>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(a => a.Residents.Any(au => au.UserId == userId))
                .ToListAsync();
        }

        public async Task<bool> NumberExistsAsync(string number)
        {
            return await _dbSet.AnyAsync(a => a.Number == number);
        }

        public async Task AssignUserToApartmentAsync(int apartmentId, int userId)
        {
            var apartmentUser = new ApartmentUser
            {
                ApartmentId = apartmentId,
                UserId = userId
            };

            _context.Set<ApartmentUser>().Add(apartmentUser);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserFromApartmentAsync(int apartmentId, int userId)
        {
            var apartmentUser = await _context.Set<ApartmentUser>()
                .FirstOrDefaultAsync(au => au.ApartmentId == apartmentId && au.UserId == userId);

            if (apartmentUser != null)
            {
                _context.Set<ApartmentUser>().Remove(apartmentUser);
                await _context.SaveChangesAsync();
            }
        }
    }
}