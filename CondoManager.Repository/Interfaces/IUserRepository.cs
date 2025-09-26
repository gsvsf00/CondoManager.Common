using CondoManager.Entity.Models;

namespace CondoManager.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByPhoneAsync(string email);
        Task<User?> GetWithApartmentsAsync(Guid id);
        Task<IEnumerable<User>> GetByApartmentIdAsync(Guid apartmentId);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> PhoneExistsAsync(string phone);
    }
}