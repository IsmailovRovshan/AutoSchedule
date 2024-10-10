using Domain.Entities;
using Domain.Entities.Users;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Persistence.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public LessonRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Lesson lesson)
        {
            await _dbContext.Lessons.AddAsync(lesson);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Lesson lesson)
        {
            _dbContext.Lessons.Remove(lesson);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _dbContext.Lessons
                .Include(l => l.Teacher)
                .Include(l => l.Client)
                .ToListAsync();
        }

        public async Task<Lesson> GetByIdAsync(Guid TeacherId, Guid ClientId)
        {
            return await _dbContext.Lessons
                .Include(l => l.Teacher)
                .Include(l => l.Client)
                .FirstOrDefaultAsync(l => l.TeacherId == TeacherId && l.ClientId == ClientId);
        }

        public async Task UpdateAsync(Lesson lesson)
        {
            _dbContext.Lessons.Update(lesson);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Lesson>> GetLessonsByDateAsync(Guid teacherId, DateTime date)
        {
            var lessons = await _dbContext.Lessons
                    .Where(l => l.TeacherId == teacherId &&
                    l.LessonDate.Year == date.Year &&
                    l.LessonDate.Month == date.Month &&
                    l.LessonDate.Day == date.Day)
                    .ToListAsync();

            return lessons;
        }

        public async Task<bool> IsTeacherFree(Teacher teacher, DateTime date)
        {
            var lessons = await _dbContext.Lessons
                .Where(l => l.TeacherId == teacher.Id)
                .Where(l => l.LessonDate.Year == date.Year &&
                    l.LessonDate.Month == date.Month &&
                    l.LessonDate.Day == date.Day &&
                    l.LessonDate.TimeOfDay == date.TimeOfDay)
                    .ToListAsync();

            if (lessons.Count == 0)
                return true;

            return false;
        }

    }
}
