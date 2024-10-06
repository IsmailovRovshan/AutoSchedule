using Domain.Enum;
namespace Contracts
{
    public record LessonDTO(Guid Id, Guid TeacherId, Guid ClientId, DateTime LessonDate, Status Status);
}
