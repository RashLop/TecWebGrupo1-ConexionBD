using System.ComponentModel.DataAnnotations;
namespace Grupo1Tarea.Models.dtos
{
    public record CreateGuestDto
    {
        [Required,StringLength(50)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public bool Confirmed { get; set; }
    }
    public record UpdateGuestDto
    {
        [Required,StringLength(50)]
        public required string FullName { get; set; }

        [Required]
        public bool Confirmed { get; set; }
    }
}
