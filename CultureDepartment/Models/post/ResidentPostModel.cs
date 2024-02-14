using CultureDepartment.Core.Entities;

namespace CultureDepartment.API.Models.post
{
    public class ResidentPostModel
    {
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public int NumBuilding { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
    }
}