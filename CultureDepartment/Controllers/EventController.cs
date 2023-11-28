using CultureDepartment.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private static List<Event> events = new List<Event>(){
            new Event(){Name="start",Description="כנס פתיחה"},
            new Event(){Name="Rosh Hashana",Description="כנס לקראת ראש השנה"}
        };
        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get(int? status) => events.Where(e => status == null || e.Status == (statusEvent)status);

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var eve = events.Find(e => e.Id == id);
            if(eve is null)
                return NotFound();
            return Ok(eve);
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event newEvent)
        {
            events.Add(newEvent);// new Event() { Name = newEvent.Name, DateTime = newEvent.DateTime, Description = newEvent.Description, Status = newEvent.Status, MinAge = newEvent.MinAge, MaxAge = newEvent.MaxAge, Min = newEvent.Min });
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Event updateEvent)
        {
            var e = events.Find(e => e.Id == id);
            if (e != null)
            {
                e.Name = updateEvent.Name;
                e.Description = updateEvent.Description;
                e.Status = updateEvent.Status;
                e.DateTime = updateEvent.DateTime;
                e.MaxAge = updateEvent.MaxAge;
                e.MinAge = updateEvent.MinAge;
                e.Min = updateEvent.Min;
                return Ok();   
            }
            return NotFound();
        }
        [HttpPut("{id}/status")]
        public IActionResult Put(int id,[FromBody] statusEvent status)
        {
            var e = events.Find(e => e.Id == id);
            if (e != null)
            {
                e.Status = status;
                return Ok();
            }
            return NotFound();
        }

    }
}
