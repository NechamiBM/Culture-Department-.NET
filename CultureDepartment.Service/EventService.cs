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

        public IEnumerable<Event> GetEvents(statusEvent? status = null) => _eventRepository.GetEvents().Where(e => status == null || e.Status.Equals(status));
        public Event GetEvent(int id) => _eventRepository.GetEvent(id);
        public void AddEvent(Event e) => _eventRepository.AddEvent(e);
        public bool UpdateEvent(int id, Event e) => _eventRepository.UpdateEvent(id, e);

        public bool UpdateEventStatus(int id, statusEvent status)
        {
            Event e = _eventRepository.GetEvent(id);
            if (e == null || status == statusEvent.Past && e.Date.CompareTo(DateTime.Now) >= 0 || e.Status == statusEvent.Past)
                return false;
            return _eventRepository.UpdateEventStatus(id, status);
        }
    }
}
