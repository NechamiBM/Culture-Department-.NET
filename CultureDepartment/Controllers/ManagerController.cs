using CultureDepartment.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private static Manager manager =new Manager();
        // GET: api/<ManagerController>
        [HttpGet]
        public Manager Get() => manager;


        // PUT api/<ManagerController>/5
        [HttpPut]
        public void Put( [FromBody] Manager m)
        {
            manager.TZ = m.TZ;
            manager.FirstName = m.FirstName;
            manager.LastName = m.LastName;
            manager.IsResident = m.IsResident;
            manager.Password = m.Password;
        }
    }
}
