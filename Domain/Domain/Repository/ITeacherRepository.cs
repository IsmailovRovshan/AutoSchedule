using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetTeacherByIdAsync(Guid id);
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task InsertTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(Guid id);
    }
}
