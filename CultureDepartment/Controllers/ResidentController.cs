using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Services;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.API.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService _residentService;
        public ResidentController(IResidentService residentService) => _residentService = residentService;

        // GET: api/<ResidentController>
        [HttpGet]
        public IEnumerable<Resident> Get(int? age) => _residentService.GetResident(age);

        // GET api/<ResidentController>/5
        [HttpGet("{tz}")]
        public IActionResult Get(string tz)
        {
            var r = _residentService.GetResident(tz);
            if (r == null)
                return NotFound();
            return Ok(r);
        }

        // POST api/<ResidentController>
        [HttpPost]
        public void Post([FromBody] Resident r) => _residentService.AddResident(r);
        // new Resident() { TZ = r.TZ, FirstName = r.FirstName, LastName = r.LastName, Age = r.Age, Street = r.Street, NumBuilding = r.NumBuilding, Phone = r.Phone });

        // PUT api/<ResidentController>/5
        [HttpPut("{tz}")]
        public IActionResult Put(string tz, [FromBody] Resident r)
        {
            if (_residentService.UpdateResident(tz, r) == true)
                return Ok();
            return NotFound();
        }

        // DELETE api/<ResidentController>/5
        [HttpDelete("{tz}")]
        public void Delete(string tz) => _residentService.DeleteResident(tz);
    }
}
