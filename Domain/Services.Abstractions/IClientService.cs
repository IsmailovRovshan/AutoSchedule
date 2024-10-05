using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IClientService
    {
        Task CreateClientAsync(Guid managerId, Client client);
        Task<Client> GetClientByIdAsync(Guid id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid id);
    }
}
