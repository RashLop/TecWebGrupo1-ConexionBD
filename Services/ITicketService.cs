using Grupo1Tarea.Models.dtos;

namespace Grupo1Tarea.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketReadDto>> GetAllAsync();
        Task<TicketReadDto?> GetByIdAsync(Guid id);
        Task<TicketReadDto> CreateAsync(CreateTicketDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateTicketDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
