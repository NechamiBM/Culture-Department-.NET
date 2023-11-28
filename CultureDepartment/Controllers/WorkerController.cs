using CultureDepartment.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private static List<Worker> workers = new List<Worker>(){
            new Worker(){ TZ="123456789",FirstName="Chaim",LastName="Choen",IsResident=true },
            new Worker(){ TZ="123456798",FirstName="Moshe",LastName="Levi",IsResident=false }
        };
        // GET: api/<WorkerController>
        [HttpGet]
        public IEnumerable<Worker> Get() => workers;

        // GET api/<WorkerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var worker = workers.Find(w => w.Id == id);
            if(worker == null)
                return NotFound();
            return Ok(worker);
        }
        
        // POST api/<WorkerController>
        [HttpPost]
        public void Post([FromBody] Worker w)
        {
            workers.Add(w);//new Worker() { TZ = w.TZ, FirstName = w.FirstName, LastName = w.LastName, IsResident = w.IsResident });
        }

        // PUT api/<WorkerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Worker w)
        {
            var worker = workers.Find(e => e.Id == id);
            if (worker != null)
            {
                worker.TZ = w.TZ;
                worker.FirstName = w.FirstName;
                worker.LastName = w.LastName;
                worker.IsResident = w.IsResident;
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<WorkerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            workers.Remove(workers.Find(w => w.Id == id));
        }
    }
}
