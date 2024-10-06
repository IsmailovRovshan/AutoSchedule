using Contracts;

namespace Services.Abstractions
{
    public interface IClientService
    {
        
        Task<ClientDTO> GetByIdAsync(Guid id);
        Task<List<ClientDTO>> GetAllAsync();
        Task<ClientDTO> CreateAsync(Guid managerId, ClientDTO client);
        Task UpdateAsync(ClientDTO client);
        Task DeleteAsync(Guid id);
    }
}
