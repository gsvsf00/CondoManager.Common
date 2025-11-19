using CondoManager.Entity.Models;

namespace CondoManager.Repository.Interfaces
{
    public interface IApartmentRepository : IRepository<Apartment>
    {
        Task<Apartment?> GetWithResidentsAsync(int id);
        Task<Apartment?> GetByNumberAsync(string number);
        Task<IEnumerable<Apartment>> GetByUserIdAsync(int userId);
        Task<bool> NumberExistsAsync(string number);
        Task AssignUserToApartmentAsync(int apartmentId, int userId);
        Task RemoveUserFromApartmentAsync(int apartmentId, int userId);
    }
}