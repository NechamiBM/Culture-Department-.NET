using CultureDepartment.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private DataContext context;
        public ManagerController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/<ManagerController>
        [HttpGet]
        public Manager Get() => context.Manager;


        // PUT api/<ManagerController>/5
        [HttpPut]
        public void Put( [FromBody] Manager m)
        {
            context.Manager.TZ = m.TZ;
            context.Manager.FirstName = m.FirstName;
            context.Manager.LastName = m.LastName;
            context.Manager.IsResident = m.IsResident;
            context.Manager.Password = m.Password;
        }
    }
}
