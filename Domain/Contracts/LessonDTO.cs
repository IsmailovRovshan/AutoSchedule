using Domain.Enum;
namespace Contracts
{
    public record LessonDto(Guid TeacherId, Guid ClientId, DateTime LessonDate, Status Status);
    public record LessonDtoForCreate(Guid TeacherId, Guid ClientId, DateTime LessonDate, Status Status);
    public record LessonDtoForUpdate(DateTime LessonDate, Status Status);
}
