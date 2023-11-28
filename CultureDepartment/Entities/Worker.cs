namespace CultureDepartment.Entities
{
    public class Worker
    {
        static int id = 0;
        public int Id { get;  }
        public string TZ { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsResident { get; set; }
        public Worker() => this.Id = ++id;
    }
}
