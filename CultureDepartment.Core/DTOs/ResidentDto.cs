using CultureDepartment.Core.Entities;

namespace CultureDepartment.Core.DTOs
{
    public class ResidentDto
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get => DateTime.Now.Year - BirthDate.Year; }
        public string Street { get; set; }
        public int NumBuilding { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }

        //public List<Event> Events { get; set; }
    }
}