using CondoManager.Entity.Models;
using CondoManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CondoManager.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByPhoneAsync(string phone)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Phone == phone);
        }

        public async Task<User?> GetWithApartmentsAsync(int id)
        {
            return await _dbSet
                .Include(u => u.Apartment)
                    .ThenInclude(au => au!.Apartment)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetByApartmentIdAsync(int apartmentId)
        {
            return await _dbSet
                .Where(u => u.Apartment != null && u.Apartment.ApartmentId == apartmentId)
                .ToListAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> PhoneExistsAsync(string phone)
        {
            return await _dbSet.AnyAsync(u => u.Phone == phone);
        }
    }
}