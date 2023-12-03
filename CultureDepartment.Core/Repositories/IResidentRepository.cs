using CultureDepartment.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Core.Repositories
{
    public interface IResidentRepository
    {
        public IEnumerable<Resident> GetResident();
        public Resident GetResident(string tz);
        public void AddResident(Resident r);
        public bool UpdateResident(string tz, Resident r);
        public void DeleteResident(string tz);
    }
}
