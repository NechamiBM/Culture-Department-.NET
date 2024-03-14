using AutoMapper;
using CultureDepartment.API.Models.post;
using CultureDepartment.API.Models.put;
using CultureDepartment.Core.DTOs;
using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Services;
using CultureDepartment.Data;
using CultureDepartment.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CultureDepartment.API.Controllers
{
    [Route("culture.co.il/[controller]")]
    [Authorize(Roles = "manager,worker")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService _residentService;
        private readonly IMapper _mapper;
        public ResidentController(IResidentService residentService, IMapper mapper)
        {
            _residentService = residentService;
            _mapper = mapper;
        }
        // GET: api/<ResidentController>
        [Authorize(Roles = "manager,worker,resident")]
        [HttpGet]
        public async Task<IActionResult> Get(int? gender, int? minage, int? maxage)
        {
            var residents = await _residentService.GetResidentsAsync((Gender?)gender, minage, maxage);
            var listDto = residents.Select(r => _mapper.Map<ResidentDto>(r));
            return Ok(listDto);
        }
        // GET api/<ResidentController>/5
        [HttpGet("{tz}")]
        public async Task<IActionResult> Get(string tz)
        {
            var resident = await _residentService.GetResidentAsync(tz);
            var residentDto = _mapper.Map<ResidentDto>(resident);
            if (residentDto is null)
                return NotFound();
            return Ok(residentDto);
        }

        // POST api/<ResidentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ResidentPostModel postResident)
        {
            var resident = await _residentService.AddResidentAsync(_mapper.Map<Resident>(postResident));
            return Ok(_mapper.Map<ResidentDto>(resident));
        }

        // PUT api/<ResidentController>/5
        [HttpPut("{tz}")]
        public async Task<IActionResult> Put(string tz, [FromBody] ResidentPutModel putResident)
        {
            var resident = await _residentService.UpdateResidentAsync(tz, _mapper.Map<Resident>(putResident));
            if (resident is null)
                return NotFound();
            return Ok(_mapper.Map<EventDto>(_mapper.Map<ResidentDto>(resident)));
        }

        // DELETE api/<ResidentController>/5
        [HttpDelete("{tz}")]
        public void Delete(string tz) => _residentService.DeleteResident(tz);
    }
}
