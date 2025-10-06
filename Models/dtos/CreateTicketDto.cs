using System.ComponentModel.DataAnnotations;

namespace Grupo1Tarea.Models
{
    public record TicketReadDto
    {
        public Guid Id { get; set; }
        public string[]? Notes { get; set; }
    }

    public record CreateTicketDto
    {
        
        [MaxLength(20)]
        public string[]? Notes { get; set; }
    }

    public record UpdateTicketDto
    {
        [MaxLength(20)]
        public string[]? Notes { get; set; }
    }
}
