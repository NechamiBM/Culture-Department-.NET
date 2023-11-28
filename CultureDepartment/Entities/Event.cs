namespace CultureDepartment.Entities
{
    public enum statusEvent { Past, Future, Cancel };
    public enum statusMin { Male, Female };
    public class Event
    {
        private static int id = 10;
        public int Id { get; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public statusEvent Status { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public statusMin Min { get; set; }
        public Event() => Id = id++;
    }
}
