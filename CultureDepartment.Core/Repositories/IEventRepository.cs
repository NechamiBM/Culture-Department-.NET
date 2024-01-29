using CultureDepartment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Core.Repositories
{
    public interface IEventRepository
    {
        public IEnumerable<Event> GetEvents();
        public Event GetEvent(int id);
        public Event UpdateEvent(int id, Event e);
        public Event UpdateEventStatus(int id, statusEvent status);
        public Event AddEvent(Event e);
    }
}
