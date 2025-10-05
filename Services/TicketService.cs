using Grupo1Tarea.Models;
using Grupo1Tarea.Repositories;

namespace Grupo1Tarea.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repo;
        public TicketService(ITicketRepository repo) => _repo = repo;

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Ticket?> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Ticket> CreateAsync(CreateTicketDto dto)
        {
            var entity = new Ticket
            {
                Id = Guid.NewGuid(),
                Notes = dto.Notes?.Select(n => n.Trim())
                                   .Where(n => !string.IsNullOrWhiteSpace(n))
                                   .ToArray()
            };
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
            return entity; 
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateTicketDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Notes = dto.Notes?.Select(n => n.Trim())
                                      .Where(n => !string.IsNullOrWhiteSpace(n))
                                      .ToArray();
            await _repo.UpdateAsync(existing);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
            var changes = await _repo.SaveChangesAsync();
            return changes > 0;
        }
    }
}
