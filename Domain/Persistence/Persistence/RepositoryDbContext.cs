using Domain.Entities;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
        }
    }
}
