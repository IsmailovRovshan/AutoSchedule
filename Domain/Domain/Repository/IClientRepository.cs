using Domain.Entities;

namespace Domain.Repository
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(Guid id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(Guid id);
    }
}
