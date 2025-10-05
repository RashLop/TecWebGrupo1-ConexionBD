using Grupo1Tarea.Models;
using Microsoft.EntityFrameworkCore;

namespace Grupo1Tarea.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Ticket>(b =>
            {
                b.ToTable("Tickets");
                b.HasKey(x => x.Id);

                b.Property(x => x.Notes).HasColumnType("text[]");
            });
        }
    }
}

