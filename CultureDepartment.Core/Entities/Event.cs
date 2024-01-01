namespace CultureDepartment.Core.Entities
{
    public enum statusEvent { Past, Future, Cancel };
    public enum statusMin { Male, Female };
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public statusEvent Status { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public statusMin Gender { get; set; }
    }
}
