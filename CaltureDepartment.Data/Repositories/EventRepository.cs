using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Repositories;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CaltureDepartment.Data.Repositories
{
    public class EventRepository: IEventRepository
    {
        private readonly DataContext _context;
        public EventRepository(DataContext context)=> _context = context;
        

        public IEnumerable<Event> GetEvents() => _context.Events;
        public Event GetEvent(int id) => _context.Events.Find(e => e.Id == id);

        public void AddEvent(Event e) => _context.Events.Add(e);
        
        public bool UpdateEvent(int id, Event updateEvent)
        {
            var e = _context.Events.Find(e => e.Id == id);
            if (e != null)
            {
                e.Name = updateEvent.Name;
                e.Description = updateEvent.Description;
                e.Status = updateEvent.Status;
                e.Date = updateEvent.Date;
                e.MaxAge = updateEvent.MaxAge;
                e.MinAge = updateEvent.MinAge;
                e.Min = updateEvent.Min;
                return true;
            }
            return false;
        }

        public bool UpdateEventStatus(int id, statusEvent status)
        {
            var e = _context.Events.Find(e => e.Id == id);
            if (e != null)
            {
                e.Status = status;
                return true;
            }
            return false;
        }
    }
}
