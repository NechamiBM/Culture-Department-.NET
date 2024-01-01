using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Repositories;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;
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

        public IEnumerable<Resident> GetResident() => _context.Residents;


        public Resident GetResident(string tz) => _context.Residents.ToList().Find(w => w.TZ.Equals(tz));
        public void AddResident(Resident r) => _context.Residents.Add(r);

        public bool UpdateResident(string tz, Resident r)
        {
            var resident = _context.Residents.ToList().Find(e => e.TZ == tz);
            if (resident != null)
            {
                resident.FirstName = r.FirstName;
                resident.LastName = r.LastName;
                resident.Street = r.Street;
                resident.NumBuilding = r.NumBuilding;
                resident.Phone = r.Phone;
                return true;
            }
            return false;
        }
        public void DeleteResident(string tz)
        {
            _context.Residents.Remove(_context.Residents.ToList().Find(r => r.TZ == tz));
        }
    }
}
