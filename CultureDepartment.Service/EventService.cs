using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Repositories;
using CultureDepartment.Core.Services;

namespace CultureDepartment.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository) => _eventRepository = eventRepository;

        public async Task<IEnumerable<Event>> GetEventsAsync(statusEvent? status, int? age)
        {
            var events = await _eventRepository.GetEventsAsync();
            return events.Where(e => (status == null || e.Status.Equals(status)) && (age == null || (age >= e.MinAge && age <= e.MaxAge)));
        }

        public async Task<Event> GetEventAsync(int id)
        {
            return await _eventRepository.GetEventAsync(id);
        }
        public async Task<Event> AddEventAsync(Event e) => await _eventRepository.AddEventAsync(e);
       
        public async Task<Event> UpdateEventAsync(int id, Event e) => await _eventRepository.UpdateEventAsync(id, e);

        public async Task<Event> UpdateEventStatusAsync(int id, statusEvent status)
        {
            Event e = await _eventRepository.GetEventAsync(id);
            if (e == null || status == statusEvent.Past && e.Date.CompareTo(DateTime.Now) >= 0 || e.Status == statusEvent.Past)
                return null;
            return await _eventRepository.UpdateEventStatusAsync(id, status);
        }
    }
}
