using Grupo1Tarea.Models;

namespace Grupo1Tarea.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket?> GetByIdAsync(Guid id);
        Task<Ticket> CreateAsync(CreateTicketDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateTicketDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
