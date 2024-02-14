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
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event> GetEventAsync(int id);
        Task<Event> AddEventAsync(Event e);
        Task<Event> UpdateEventAsync(int id, Event e);
        Task<Event> UpdateEventStatusAsync(int id, statusEvent status);
    }
}
