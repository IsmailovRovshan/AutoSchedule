using Contracts;

namespace Services.Abstractions
{
    public interface IManagerService
    {
        Task<ClientDTO> CreateClientAsync(ClientDTO clientDto);
        Task UpdateClientAsync(ClientDTO clientDto);
        Task DeleteClientAsync(Guid ClientId);
        Task AutoSearchTeacherForClient(Guid clientId, DateTime lessonDate);
    }
}
