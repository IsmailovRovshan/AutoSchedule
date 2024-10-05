using Domain.Entities.Users;

namespace Domain.Repository
{
    public interface IManagerRepository
    {
        Task<Manager> GetByIdAsync(Guid id);
        Task<IEnumerable<Manager>> GetAllAsync();
        Task AddAsync(Manager manager);
        Task UpdateAsync(Manager manager);
        Task DeleteAsync(Guid id);
    }
}
