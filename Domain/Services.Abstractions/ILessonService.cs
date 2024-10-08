using Contracts;

namespace Services.Abstractions
{
    public interface ILessonService
    {
        Task<LessonDto> GetByIdAsync(Guid lessonId); 
        Task<List<LessonDto>> GetAllAsync(); 
        Task<LessonDto> CreateAsync(LessonDtoForCreate lessonDto); 
        Task UpdateAsync(Guid lessonId, LessonDtoForUpdate lessonDto); 
        Task DeleteAsync(Guid lessonId); 
    }
}
