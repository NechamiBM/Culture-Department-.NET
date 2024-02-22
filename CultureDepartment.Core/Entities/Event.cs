namespace CultureDepartment.Core.Entities
{
    public enum statusEvent { Past, Future, Cancel };
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public statusEvent Status { get; set; } = statusEvent.Future;
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public Gender Gender { get; set; }
        public List<Resident> Residents { get; set; }
        public int WorkerId { get; set; }
        public Worker EventWorker { get; set; }
    }
}
