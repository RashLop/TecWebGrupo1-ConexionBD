using System.ComponentModel.DataAnnotations;

namespace Grupo1Tarea.Models.dtos
{
    public class CreateEventDto
    {
        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }
        [Range(1, 10000)]
        public int Capacity { get; set; }
    }
}
