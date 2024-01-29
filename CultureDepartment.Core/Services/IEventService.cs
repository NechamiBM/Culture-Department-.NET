using CultureDepartment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Core.Services
{
    public interface IEventService
    {
        public IEnumerable<Event> GetEvents(statusEvent? status = null);
        public Event GetEvent(int id);
        public Event AddEvent(Event e);
        public Event UpdateEvent(int id, Event e);
        public Event UpdateEventStatus(int id, statusEvent status);
    }
}
