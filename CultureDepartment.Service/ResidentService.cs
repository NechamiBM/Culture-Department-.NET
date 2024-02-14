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

        public async Task<IEnumerable<Resident>> GetResidentsAsync(Gender? gender, int? minAge, int? maxAge)
        {
            var residents = await _residentRepository.GetResidentsAsync();
            return residents.Where(r =>
            (minAge == null || r.Age >= minAge) &&
            (maxAge == null || r.Age <= maxAge) &&
            (gender == null || r.Gender == gender));
        }
        public async Task<Resident> GetResidentAsync(string tz) => await _residentRepository.GetResidentAsync(tz);
        public async Task<Resident> AddResidentAsync(Resident r) => await _residentRepository.AddResidentAsync(r);
        public async Task<Resident> UpdateResidentAsync(string tz, Resident r) => await _residentRepository.UpdateResidentAsync(tz, r);
        public void DeleteResident(string tz) => _residentRepository.DeleteResident(tz);
    }
}
