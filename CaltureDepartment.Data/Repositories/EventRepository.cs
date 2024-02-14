using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Repositories;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CaltureDepartment.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;
        public EventRepository(DataContext context) => _context = context;

        public async Task<IEnumerable<Event>> GetEventsAsync() => await _context.Events.ToListAsync();
        public async Task<Event> GetEventAsync(int id) => await _context.Events.FindAsync(id);
        public async Task<Event> AddEventAsync(Event e)
        {
            _context.Events.Add(e);
            await _context.SaveChangesAsync();
            return e;
        }
        public async Task<Event> UpdateEventAsync(int id, Event updateEvent)
        {
            var e = _context.Events.Find(id);
            if (e != null)
            {
                e.Name = updateEvent.Name;
                e.Description = updateEvent.Description;
                e.Status = updateEvent.Status;
                e.Date = updateEvent.Date;
                e.MaxAge = updateEvent.MaxAge;
                e.MinAge = updateEvent.MinAge;
                e.Gender = updateEvent.Gender;
            }
            await _context.SaveChangesAsync();
            return updateEvent;
        }

        public async Task<Event> UpdateEventStatusAsync(int id, statusEvent status)
        {
            var e = _context.Events.Find(id);
            if (e != null)
                e.Status = status;
            await _context.SaveChangesAsync();
            return e;
        }
    }
}
