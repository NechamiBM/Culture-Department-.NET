namespace CultureDepartment.Core.Entities
{
    public class Resident 
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private DateOnly _birthDate;
        public int Age { get => DateTime.Now.Year - _birthDate.Year; }
        public string Street { get; set; }
        public int NumBuilding { get; set; }
        public string Phone { get; set; }
        public List<Event> Events { get; set; }
    }
}