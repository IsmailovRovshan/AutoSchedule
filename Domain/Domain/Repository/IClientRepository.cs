using Domain.Entities;

namespace Domain.Repository
{
    public interface IClientRepository
    {
        Task<Client> GetClientByIdAsync(Guid id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task InsertClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid id);
    }
}
