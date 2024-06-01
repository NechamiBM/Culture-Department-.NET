namespace CultureDepartment.API.Models.post
{
    public class WorkerPostModel
    {
        [ValidateIdentity(ErrorMessage = "Identity is not valid.")]
        public string Identity { get; set; }
        public string Name { get; set; }
        public bool IsResident { get; set; }
    }
}
