using Grupo1Tarea.Data;
using Grupo1Tarea.Models;
using Microsoft.EntityFrameworkCore;
namespace Grupo1Tarea.Repositories
{
    public class EventRepository:IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Event evt)
        {
            await _context.Events.AddAsync(evt);
        }

        public async Task Delete(Guid id)
        {
            var evt = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (evt != null)
            {
                _context.Events.Remove(evt);
            }
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetById(Guid id)
        {
            return await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
