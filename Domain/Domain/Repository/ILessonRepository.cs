using Domain.Entities;

namespace Domain.Repository
{
    public interface ILessonRepository
    {
        Task<Lesson> GetByIdAsync(Guid id);
        Task<IEnumerable<Lesson>> GetAllAsync();
        Task AddAsync(Lesson lesson);
        Task UpdateAsync(Lesson lesson);
        Task DeleteAsync(Guid id);
    }
}
