namespace CultureDepartment.Core.Entities
{
    public class Manager:Worker
    {
        private int id = 1;
        public string Password { get; set; }
        public Manager():base()
        {
            this.Password = "Manager$1"; 
        }

    }
}
