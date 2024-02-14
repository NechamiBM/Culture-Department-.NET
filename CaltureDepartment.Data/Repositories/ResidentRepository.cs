using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Repositories;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaltureDepartment.Data.Repositories
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly DataContext _context;

        public ResidentRepository(DataContext context) => _context = context;

        public async Task<IEnumerable<Resident>> GetResidentsAsync() => await _context.Residents.ToListAsync();

        public async Task<Resident> GetResidentAsync(string tz) => await _context.Residents.FindAsync(tz);

        public async Task<Resident> AddResidentAsync(Resident r)
        {
            _context.Residents.Add(r);
            await _context.SaveChangesAsync();
            return r;
        }

        public async Task<Resident> UpdateResidentAsync(string tz, Resident r)
        {
            var resident = _context.Residents.Find(tz);
            if (resident != null)
            {
                resident.FirstName = r.FirstName;
                resident.LastName = r.LastName;
                resident.Street = r.Street;
                resident.NumBuilding = r.NumBuilding;
                resident.Phone = r.Phone;
            }
            await _context.SaveChangesAsync();
            return r;
        }
        public void DeleteResident(string tz)
        {
            _context.Residents.Remove(_context.Residents.Find(tz));
        }
    }
}
