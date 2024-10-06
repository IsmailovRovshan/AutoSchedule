using Contracts;
using Domain.Enum;


namespace Services.Abstractions
{
    public interface ITeacherService
    {
        Task SetWorkingHourseAsync(Guid Id, DateTime startWork, DateTime endWork);
        Task<List<LessonDTO>> GetAllLessons(Guid teacherId);
        Task UpdateLessonStatusAsync(Guid lessonId, Status status);
    }
}
