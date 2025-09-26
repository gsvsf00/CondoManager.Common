using CondoManager.Entity.Models;

namespace CondoManager.Repository.Interfaces
{
    public interface IApartmentRepository : IRepository<Apartment>
    {
        Task<Apartment?> GetWithResidentsAsync(Guid id);
        Task<Apartment?> GetByNumberAsync(string number);
        Task<IEnumerable<Apartment>> GetByUserIdAsync(Guid userId);
        Task<bool> NumberExistsAsync(string number);
        Task AssignUserToApartmentAsync(Guid apartmentId, Guid userId);
        Task RemoveUserFromApartmentAsync(Guid apartmentId, Guid userId);
    }
}