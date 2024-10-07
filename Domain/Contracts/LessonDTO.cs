using Domain.Enum;
namespace Contracts
{
    public record LessonDto(Guid Id, Guid TeacherId, Guid ClientId, DateTime LessonDate, Status Status);
}
