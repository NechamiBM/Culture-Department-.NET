using Microsoft.AspNetCore.Mvc;

namespace CultureDepartment.Entities
{
    public class Resident
    {
        public string TZ { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Street { get; set; }
        public int NumBuilding { get; set; }
        public string Phone { get; set; }
        public Resident(string tz)
        {
            this.TZ = tz;
        }

    }
}
