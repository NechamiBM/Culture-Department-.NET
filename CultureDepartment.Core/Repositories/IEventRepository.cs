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
        public bool UpdateEvent(int id, Event e);
        public bool UpdateEventStatus(int id, statusEvent status);
        public void AddEvent(Event e);
    }
}
