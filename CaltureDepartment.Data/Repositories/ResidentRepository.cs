using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Repositories;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CaltureDepartment.Data.Repositories
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly DataContext _context;

        public ResidentRepository(DataContext context) => _context = context;

        public async Task<IEnumerable<Resident>> GetResidentsAsync() => await _context.Residents.ToListAsync();

        public async Task<Resident> GetResidentAsync(string identity) => await _context.Residents.FirstOrDefaultAsync(t => t.Identity == identity);

        public async Task<Resident> AddResidentAsync(Resident r)
        {
            _context.Residents.Add(r);
            await _context.SaveChangesAsync();
            return r;
        }

        public async Task<Resident> UpdateResidentAsync(string identity, Resident r)
        {
            var resident = await _context.Residents.FirstOrDefaultAsync(t => t.Identity == identity);
            if (resident != null)
            {
                resident.FirstName = r.FirstName;
                resident.LastName = r.LastName;
                resident.Street = r.Street;
                resident.NumBuilding = r.NumBuilding;
                resident.Phone = r.Phone;
            }
            await _context.SaveChangesAsync();
            return resident;
        }
        public void DeleteResident(string identity)
        {
            var residentToDelete = _context.Residents.FirstOrDefault(t => t.Identity == identity);
            if (residentToDelete != null)
                _context.Residents.Remove(residentToDelete);
            _context.SaveChanges();
        }
    }
}
