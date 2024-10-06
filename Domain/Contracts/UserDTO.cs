namespace Contracts
{
    public record CreateUserDTO(string FullName, string Login, string Password, string Email);
    public record LoginUserDTO(string Login, string Password);
}
