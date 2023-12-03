using CultureDepartment.Core.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Core.Services
{
    public interface IResidentService
    {
        public IEnumerable<Resident> GetResident(int? age);
        public Resident GetResident(string tz);
        public void AddResident(Resident r);
        public bool UpdateResident(string tz, Resident r);
        public void DeleteResident(string tz);
    }
}
