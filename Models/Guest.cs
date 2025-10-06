namespace Grupo1Tarea.Models
{
    public class Guest
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public bool Confirmed { get; set; }
    }
}
