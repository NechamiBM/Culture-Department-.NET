namespace CultureDepartment.Entities
{
    public class Manager:Worker
    {
        public string Password { get; set; }
        public Manager():base()
        {
            this.Password = "Manager$1"; 
        }

    }
}
