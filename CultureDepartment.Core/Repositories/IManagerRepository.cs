using CultureDepartment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Core.Repositories
{
    public interface IManagerRepository
    {
        Task<Manager> GetManagerAsync();
        Task<Manager> UpdateManegerAsync(Manager m);
    }
}
