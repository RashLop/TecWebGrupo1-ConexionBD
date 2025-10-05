using Grupo1Tarea.Data;
using Grupo1Tarea.Models;
using Microsoft.EntityFrameworkCore;

namespace Grupo1Tarea.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;
        public TicketRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Ticket>> GetAllAsync()
            => await _context.Tickets.AsNoTracking().ToListAsync();

        public async Task<Ticket?> GetByIdAsync(Guid id)
            => await _context.Tickets.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        public Task AddAsync(Ticket ticket) => _context.Tickets.AddAsync(ticket).AsTask();

        public Task UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (entity != null) _context.Tickets.Remove(entity);
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
