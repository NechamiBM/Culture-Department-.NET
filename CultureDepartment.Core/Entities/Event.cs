namespace CultureDepartment.Core.Entities
{
    public enum statusEvent { Past, Future, Cancel };
    public enum Gender { Male, Female };
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public statusEvent Status { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public Gender Gender { get; set; }
        public List<Resident> Residents { get; set; }
    }
}
