using Domain.Entities;

namespace Domain.Repository
{
    public interface IManagerRepository
    {
        Task<Manager> GetManagerByIdAsync(Guid id);
        Task<IEnumerable<Manager>> GetAllManagersAsync();
        Task AddManagerAsync(Manager manager);
        Task UpdateManagerAsync(Manager manager);
        Task DeleteManagerAsync(Guid id);
    }
}
