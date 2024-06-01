using CultureDepartment.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace CultureDepartment.API.Models.post
{
    public class ResidentPostModel
    {
        [ValidateIdentity(ErrorMessage = "Identity is not valid.")]
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public int NumBuilding { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
    }
}