using AutoMapper;
using CultureDepartment.API.Models.post;
using CultureDepartment.Core.DTOs;
using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.API.Controllers
{
    [Route("culture.co.il/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        // GET: api/<EventController>
        [HttpGet]
        public async Task<IActionResult> Get(int? status, int? age)
        {
            var events = await _eventService.GetEventsAsync((statusEvent?)status, age);
            var listDto = events.Select(e => _mapper.Map<EventDto>(e));
            return Ok(listDto);
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var eve = await _eventService.GetEventAsync(id);
            var eventDto = _mapper.Map<EventDto>(eve);
            if (eventDto is null)
                return NotFound();
            return Ok(eventDto);
        }

        // POST api/<EventController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventPostModel postEvent)
        {
            var eve = await _eventService.AddEventAsync(_mapper.Map<Event>(postEvent));
            var newEve = await _eventService.GetEventAsync(eve.Id);
            return Ok(_mapper.Map<EventDto>(newEve));
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EventPostModel putEvent)
        {
            var eve = await _eventService.UpdateEventAsync(id, _mapper.Map<Event>(putEvent));
            var newEve = await _eventService.GetEventAsync(eve.Id);
            if (newEve is null)
                return NotFound();
            return Ok(newEve);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> Put(int id, [FromBody] statusEvent status)
        {
            var eve = await _eventService.UpdateEventStatusAsync(id, status);
            var newEve = await _eventService.GetEventAsync(eve.Id);
            if (newEve is null)
                return NotFound();
            return Ok(newEve);
        }

    }
}
