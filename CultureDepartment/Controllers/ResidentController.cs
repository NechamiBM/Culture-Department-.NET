using CultureDepartment.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private DataContext context;
        public ResidentController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/<ResidentController>
        [HttpGet]
        public IEnumerable<Resident> Get(int? age)=> context.Residents.Where(r => age == null || r.Age == age);

        // GET api/<ResidentController>/5
        [HttpGet("{tz}")]
        public IActionResult Get(string tz)
        {
            var r = context.Residents.Find(w => w.TZ.Equals(tz));
            if (r == null)
                return NotFound();
            return Ok(r);
        }

        // POST api/<ResidentController>
        [HttpPost]
        public void Post([FromBody] Resident r)
        {
            context.Residents.Add(r);// new Resident() { TZ = r.TZ, FirstName = r.FirstName, LastName = r.LastName, Age = r.Age, Street = r.Street, NumBuilding = r.NumBuilding, Phone = r.Phone });
        }

        // PUT api/<ResidentController>/5
        [HttpPut("{tz}")]
        public IActionResult Put(string tz, [FromBody] Resident r)
        {
            var resident = context.Residents.Find(e => e.TZ == tz);
            if (resident != null)
            {
                resident.FirstName = r.FirstName;
                resident.LastName = r.LastName;
                resident.Age = r.Age;
                resident.Street = r.Street;
                resident.NumBuilding = r.NumBuilding;
                resident.Phone = r.Phone;
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<ResidentController>/5
        [HttpDelete("{tz}")]
        public void Delete(string tz)=> context.Residents.Remove(context.Residents.Find(r => r.TZ == tz));
    }
}
