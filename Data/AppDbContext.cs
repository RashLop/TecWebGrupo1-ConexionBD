using Grupo1Tarea.Models;
using Microsoft.EntityFrameworkCore;
namespace Grupo1Tarea.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}