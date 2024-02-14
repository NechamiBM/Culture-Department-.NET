using CultureDepartment.Core.Entities;

namespace CultureDepartment.API.Models.put
{
    public class ResidentPutModel
    {
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int NumBuilding { get; set; }
        public string Phone { get; set; }
    }
}
