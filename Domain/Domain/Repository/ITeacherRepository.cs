using Domain.Entities;
using Domain.Entities.Users;
using System.Data;

namespace Domain.Repository
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetByIdAsync(Guid id);
        Task<List<Teacher>> GetAllAsync();
        Task AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(Teacher teacher);

        Task<List<Teacher>> TeachersCanWorkAtThisTime(DateTime lessonDate);
    }
}
