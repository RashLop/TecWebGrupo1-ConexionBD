using Grupo1Tarea.Models;
using Grupo1Tarea.Models.dtos;

namespace Grupo1Tarea.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task<Event> Create(CreateEventDto dto);
        Task<bool> Delete(Guid id);
    }
}
