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
        private static List<Resident> residents = new List<Resident>(){
            new Resident("326679313"){FirstName="נחמי",LastName="בן מנחם",Age=19, Street="בלז", NumBuilding=13,Phone="035783598" },
            new Resident("325749315"){FirstName="שבי",LastName="אורנשטיין",Age=19,Street="קוטלר", NumBuilding=12 ,Phone="036198243" }
        };
        // GET: api/<ResidentController>
        [HttpGet]
        public IEnumerable<Resident> Get(int? age)=> residents.Where(r => age == null || r.Age == age);

        // GET api/<ResidentController>/5
        [HttpGet("{tz}")]
        public IActionResult Get(string tz)
        {
            var r = residents.Find(w => w.TZ.Equals(tz));
            if (r == null)
                return NotFound();
            return Ok(r);
        }

        // POST api/<ResidentController>
        [HttpPost]
        public void Post([FromBody] Resident r)
        {
            residents.Add(r);// new Resident() { TZ = r.TZ, FirstName = r.FirstName, LastName = r.LastName, Age = r.Age, Street = r.Street, NumBuilding = r.NumBuilding, Phone = r.Phone });
        }

        // PUT api/<ResidentController>/5
        [HttpPut("{tz}")]
        public IActionResult Put(string tz, [FromBody] Resident r)
        {
            var resident = residents.Find(e => e.TZ == tz);
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
        public void Delete(string tz)=> residents.Remove(residents.Find(r => r.TZ == tz));
    }
}
