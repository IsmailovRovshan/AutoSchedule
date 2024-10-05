namespace Contracts
{
    public record TeacherDto(Guid Id, string FullName, string Email, DateTime StartWork, DateTime EndWork);
}
