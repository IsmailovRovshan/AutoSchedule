using Domain.Entities.Users;

namespace Contracts
{
    public record ClientDto(Guid Id, string FullName, int Age, Guid ManagerId);
    public record ClientDtoForCreate(string FullName, int Age, Guid ManagerId);
    public record ClientDtoForUpdate(string FullName, int Age);
}
