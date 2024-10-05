using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetByIdAsync(Guid id);
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(Guid id);
    }
}
