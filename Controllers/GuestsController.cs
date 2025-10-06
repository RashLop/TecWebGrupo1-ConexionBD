using Grupo1Tarea.Models.dtos;
using Grupo1Tarea.Services;
using Microsoft.AspNetCore.Mvc;

namespace Grupo1Tarea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _service;
        public GuestsController(IGuestService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var guests = await _service.GetAll();
            return Ok(guests);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var guest = await _service.GetById(id);
            return guest == null
                ? NotFound(new { error = "Guest not found", status = 404 })
                : Ok(guest);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGuestDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var guest = await _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = guest.Id }, guest);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Guest not found", status = 404 });
        }
    }
}
