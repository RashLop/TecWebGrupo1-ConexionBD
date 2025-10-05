using System.ComponentModel.DataAnnotations;

namespace Grupo1Tarea.Models
{
    public class TicketReadDto
    {
        public Guid Id { get; set; }
        public string[]? Notes { get; set; }
    }

    public class CreateTicketDto
    {
        
        [MaxLength(20)]
        public string[]? Notes { get; set; }
    }

    public class UpdateTicketDto
    {
        [MaxLength(20)]
        public string[]? Notes { get; set; }
    }
}
