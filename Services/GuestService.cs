using Grupo1Tarea.Models;
using Grupo1Tarea.Models.dtos;
using Grupo1Tarea.Repositories;

namespace Grupo1Tarea.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _repo;
        public GuestService(IGuestRepository repo)
        {
            _repo = repo;
        }
        public async Task<Guest> Create(CreateGuestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
            {
                throw new InvalidOperationException("Full name required");
            }
            var guest = new Guest
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName.Trim(),
                Confirmed = dto.Confirmed,
            };
            await _repo.Add(guest);
            return guest;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;
            await _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Guest?> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }
    }
}

