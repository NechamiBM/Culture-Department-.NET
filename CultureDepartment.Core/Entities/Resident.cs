namespace CultureDepartment.Core.Entities
{
    public class Resident : Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private DateOnly _birthDate;
        public int Age { get => DateTime.Now.Year - _birthDate.Year; }
        public string Street { get; set; }
        public int NumBuilding { get; set; }
        public string Phone { get; set; }

        public Resident(string tz, DateOnly birthDate) : base(tz, birthDate)
        {
            this.TZ = tz;
        }
        public Resident()  { }
    }
}