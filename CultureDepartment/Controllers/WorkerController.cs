using AutoMapper;
using CultureDepartment.API.Models.post;
using CultureDepartment.Core.DTOs;
using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Services;
using CultureDepartment.Data;
using CultureDepartment.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.API.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;
        private readonly IMapper _mapper;
        public WorkerController(IWorkerService workerService, IMapper mapper)
        {
            _workerService = workerService;
            _mapper = mapper;
        }
        // GET: api/<WorkerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var workers = await _workerService.GetWorkersAsync();
            var listDto = workers.Select(w => _mapper.Map<WorkerDto>(w));
            return Ok(listDto);
        }
        // GET api/<WorkerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var worker = await _workerService.GetWorkerAsync(id);
            var workerDto = _mapper.Map<WorkerDto>(worker);
            if (workerDto is null)
                return NotFound();
            return Ok(workerDto);
        }

        // POST api/<WorkerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkerPostModel postWorker)
        {
            var worker = await _workerService.AddWorkerAsync(_mapper.Map<Worker>(postWorker));
            return Ok(_mapper.Map<WorkerDto>(worker));
        }
        // PUT api/<WorkerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WorkerPostModel putWorker)
        {
            var worker = await _workerService.UpdateWorkerAsync(id, _mapper.Map<Worker>(putWorker));
            var workerDto = _mapper.Map<WorkerDto>(worker);
            if (workerDto is null)
            return NotFound();
                return Ok(workerDto);
        }

        // DELETE api/<WorkerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) => _workerService.DeleteWorker(id);
    }
}
