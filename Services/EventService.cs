using Grupo1Tarea.Models;
using Grupo1Tarea.Models.dtos;
using Grupo1Tarea.Repositories;

namespace Grupo1Tarea.Services
{
    public class EventService:IEventService
    {

        private readonly IEventRepository _repo;

        public EventService(IEventRepository repo)
        {
            _repo = repo;
        }

        public async Task<Event> Create(CreateEventDto dto)
        {
            if (dto.Capacity < 1)
                throw new InvalidOperationException("Capacity must be at least 1.");

            var evt = new Event
            {
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Date = dto.Date,
                Capacity = dto.Capacity
            };

            await _repo.Add(evt);
            return evt;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;

            await _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Event?> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }
    }
}
