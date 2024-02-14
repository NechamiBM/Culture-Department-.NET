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
        Task<IEnumerable<Resident>> GetResidentsAsync();
        Task<Resident> GetResidentAsync(string tz);
        Task<Resident> AddResidentAsync(Resident r);
        Task<Resident> UpdateResidentAsync(string tz, Resident r);
        void DeleteResident(string tz);
    }
}
