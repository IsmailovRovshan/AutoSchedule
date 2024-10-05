namespace Contracts
{
    public record LessonDTO(Guid Id, Guid TeacherId, Guid ClientId, DateTime LessonDate, bool IsCompleted);
}
