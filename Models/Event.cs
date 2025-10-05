namespace Grupo1Tarea.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
    }
}
