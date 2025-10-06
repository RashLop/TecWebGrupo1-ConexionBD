using Grupo1Tarea.Data;
using Grupo1Tarea.Models;
using Microsoft.EntityFrameworkCore;

namespace Grupo1Tarea.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly AppDbContext _context;
        public GuestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Guest guest)
        {
            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.Id == id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetById(Guid id)
        {
            return await _context.Guests.FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
