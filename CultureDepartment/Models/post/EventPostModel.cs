using CultureDepartment.Core.Entities;

namespace CultureDepartment.API.Models.post
{
    public class EventPostModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public statusEvent Status { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public Gender Gender { get; set; }
        public int EventWorkerId { get; set; }
    }
}
