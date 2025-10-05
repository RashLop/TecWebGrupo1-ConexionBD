using Grupo1Tarea.Models;

namespace Grupo1Tarea.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket?> GetByIdAsync(Guid id);
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
