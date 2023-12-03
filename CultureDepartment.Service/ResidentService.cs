using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Repositories;
using CultureDepartment.Core.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Service
{
    public class ResidentService : IResidentService
    {
        private readonly IResidentRepository _residentRepository;
        public ResidentService(IResidentRepository residentRepository) => _residentRepository = residentRepository;

        public IEnumerable<Resident> GetResident(int? age) => _residentRepository.GetResident().Where(r => age == null || r.Age >= age);
        public Resident GetResident(string tz) => _residentRepository.GetResident(tz);
        public void AddResident(Resident r) => _residentRepository.AddResident(r);
        public bool UpdateResident(string tz, Resident r) => _residentRepository.UpdateResident(tz, r);
        public void DeleteResident(string tz) => _residentRepository.DeleteResident(tz);
    }
}
