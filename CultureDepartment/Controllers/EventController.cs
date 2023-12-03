using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Services;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.API.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService) => _eventService = eventService;

        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get(int? status) => _eventService.GetEvents((statusEvent?)status);

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var eve = _eventService.GetEvent(id);
            if (eve is null)
                return NotFound();
            return Ok(eve);
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event newEvent) => _eventService.AddEvent(newEvent);
        // new Event() { Name = newEvent.Name, DateTime = newEvent.DateTime, Description = newEvent.Description, Status = newEvent.Status, MinAge = newEvent.MinAge, MaxAge = newEvent.MaxAge, Min = newEvent.Min });

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Event updateEvent)
        {
            if (_eventService.UpdateEvent(id, updateEvent) == true)
                return Ok();
            return NotFound();
        }

        [HttpPut("{id}/status")]
        public IActionResult Put(int id, [FromBody] statusEvent status)
        {
            if (_eventService.UpdateEventStatus(id, status) == true)
                return Ok();
            return NotFound();
        }

    }
}
