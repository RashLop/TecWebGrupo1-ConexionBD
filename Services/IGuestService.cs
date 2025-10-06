using Grupo1Tarea.Models;
using Grupo1Tarea.Models.dtos;

namespace Grupo1Tarea.Services
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task<Guest> Create(CreateGuestDto dto);


        Task<bool> Delete(Guid id);
    }
}