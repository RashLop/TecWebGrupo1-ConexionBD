using Grupo1Tarea.Models;

namespace Grupo1Tarea.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task Add(Guest guest);
        Task Delete(Guid id);
    }
}
