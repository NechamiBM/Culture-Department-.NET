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
        Task<IEnumerable<Resident>> GetResidentsAsync(Gender? gender, int? minAge, int? maxAge);
        Task<Resident> GetResidentAsync(string tz);
        Task<Resident> AddResidentAsync(Resident r);
        Task<Resident> UpdateResidentAsync(string tz, Resident r);
        void DeleteResident(string tz);
    }
}
