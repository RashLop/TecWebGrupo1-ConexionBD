using Grupo1Tarea.Models;
using Microsoft.EntityFrameworkCore;

namespace Grupo1Tarea.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Event> Events => Set<Event>();

        public DbSet<Guest> Guests => Set<Guest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ticket>(b =>
            {
                b.ToTable("Tickets");
                b.HasKey(x => x.Id);
                b.Property(x => x.Notes).HasColumnType("text[]");
            });
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

