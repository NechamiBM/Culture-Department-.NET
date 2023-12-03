using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Services;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.API.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService) => _managerService = managerService;

        // GET: api/<ManagerController>
        [HttpGet]
        public Manager Get() => _managerService.GetManager();

        // PUT api/<ManagerController>/5
        [HttpPut]
        public void Put([FromBody] Manager m) => _managerService.UpdateManeger(m);
    }
}
