namespace CultureDepartment.Core.Entities
{
    public class Resident
    {
        public string TZ { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private DateOnly _birthDate;
        public int Age { get => DateTime.Now.Year - _birthDate.Year; }
        public string Street { get; set; }
        public int NumBuilding { get; set; }
        public string Phone { get; set; }

        public Resident(string tz,DateOnly birthDate)
        {
            _birthDate = birthDate;
            this.TZ = tz;
        }

    }
}
