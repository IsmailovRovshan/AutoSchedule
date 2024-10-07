namespace Contracts
{
    public record ManagerDto(Guid Id, string Login,string Password, string FullName, string Email);
    public record ManagerDtoForCreate(string Login,string Password, string FullName, string Email);
    public record ManagerDtoForUpdate(string Email);
}
