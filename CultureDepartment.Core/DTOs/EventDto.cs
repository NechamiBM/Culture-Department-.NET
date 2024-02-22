using CultureDepartment.Core.Entities;

namespace CultureDepartment.Core.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public statusEvent Status { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public Gender Gender { get; set; }
    }
}
