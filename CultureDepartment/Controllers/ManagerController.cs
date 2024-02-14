using AutoMapper;
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
        private readonly IMapper _mapper;
        public ManagerController(IManagerService managerService, IMapper mapper)
        {
            _managerService = managerService;
            _mapper = mapper;
        }

        // GET: api/<ManagerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _managerService.GetManagerAsync());
        }
        // PUT api/<ManagerController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Manager m)
        {
            return Ok(await _managerService.UpdateManegerAsync(m));
        }
    }
}
