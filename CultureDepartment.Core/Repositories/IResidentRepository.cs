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
        Task<Resident> GetResidentAsync(string identity);
        Task<Resident> AddResidentAsync(Resident r);
        Task<Resident> UpdateResidentAsync(string identity, Resident r);
        void DeleteResident(string identity);
    }
}
