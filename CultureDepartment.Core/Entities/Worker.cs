namespace CultureDepartment.Core.Entities
{
    public class Worker : Person
    {
        public string TZ { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsResident { get; set; }
    }
}
