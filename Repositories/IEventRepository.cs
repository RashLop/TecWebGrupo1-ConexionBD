using Grupo1Tarea.Models;

namespace Grupo1Tarea.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task Add(Event evt);
        Task Delete(Guid id);
    }
}
