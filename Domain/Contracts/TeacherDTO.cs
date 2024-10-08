namespace Contracts
{
    public record TeacherDto(Guid Id, string Login, string Password, string Email, string FullName, DateTime StartWork, DateTime EndWork);
    public record TeacherDtoForCreate(string Login, string Password, string Email, string FullName, DateTime StartWork, DateTime EndWork);
    public record TeacherDtoForUpdate(string Email, DateTime StartWork, DateTime EndWork);
}
