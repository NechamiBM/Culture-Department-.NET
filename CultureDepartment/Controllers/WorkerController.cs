using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Services;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.API.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;
        public WorkerController(IWorkerService workerService) => _workerService = workerService;

        // GET: api/<WorkerController>
        [HttpGet]
        public IEnumerable<Worker> Get() => _workerService.GetWorkers();

        // GET api/<WorkerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var worker = _workerService.GetWorker(id);
            if (worker == null)
                return NotFound();
            return Ok(worker);
        }

        // POST api/<WorkerController>
        [HttpPost]
        public void Post([FromBody] Worker w) => _workerService.AddWorker(w);
        //new Worker() { TZ = w.TZ, FirstName = w.FirstName, LastName = w.LastName, IsResident = w.IsResident });

        // PUT api/<WorkerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Worker w)
        {
            if (_workerService.UpdateWorker(id, w) != null)
                return Ok();
            return NotFound();
        }

        // DELETE api/<WorkerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) => _workerService.DeleteWorker(id);
    }
}
