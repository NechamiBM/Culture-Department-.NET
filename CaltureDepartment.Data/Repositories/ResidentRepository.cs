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


        public Resident GetResident(string tz) => _context.Residents.Find(tz);
        public Resident AddResident(Resident r) 
        { 
            _context.Residents.Add(r);
            _context.SaveChanges();
            return r;
        }

        public Resident UpdateResident(string tz, Resident r)
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
            _context.SaveChanges();
            return r;
        }
        public void DeleteResident(string tz)
        {
            _context.Residents.Remove(_context.Residents.Find(tz));
        }
    }
}
