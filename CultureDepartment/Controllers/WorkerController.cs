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
        private DataContext context;
        public WorkerController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/<WorkerController>
        [HttpGet]
        public IEnumerable<Worker> Get() => context.Workers;

        // GET api/<WorkerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var worker = context.Workers.Find(w => w.Id == id);
            if(worker == null)
                return NotFound();
            return Ok(worker);
        }
        
        // POST api/<WorkerController>
        [HttpPost]
        public void Post([FromBody] Worker w)
        {
            context.Workers.Add(w);//new Worker() { TZ = w.TZ, FirstName = w.FirstName, LastName = w.LastName, IsResident = w.IsResident });
        }

        // PUT api/<WorkerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Worker w)
        {
            var worker = context.Workers.Find(e => e.Id == id);
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
            context.Workers.Remove(context.Workers.Find(w => w.Id == id));
        }
    }
}
