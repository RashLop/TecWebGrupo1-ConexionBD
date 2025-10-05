using Grupo1Tarea.Models;
using Microsoft.EntityFrameworkCore;
namespace Grupo1Tarea.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Event> Events => Set<Event>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).IsRequired().HasMaxLength(200);
                e.Property(x => x.Date).IsRequired();
                e.Property(x => x.Capacity).IsRequired();
            });
        }
    }
}