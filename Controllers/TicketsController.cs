using Grupo1Tarea.Models.dtos;
using Grupo1Tarea.Services;
using Microsoft.AspNetCore.Mvc;

namespace Grupo1Tarea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;
        public TicketsController(ITicketService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var ticket = await _service.GetByIdAsync(id);
            return ticket == null
                ? NotFound(new { error = "Ticket not found", status = 404 })
                : Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var ticket = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetOne), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTicketDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound(new { error = "Ticket not found", status = 404 });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound(new { error = "Ticket not found", status = 404 });
        }
    }
}
