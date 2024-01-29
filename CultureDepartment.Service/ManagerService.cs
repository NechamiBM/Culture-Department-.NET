using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Repositories;
using CultureDepartment.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Service
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        public ManagerService(IManagerRepository managerRepository) => _managerRepository = managerRepository;

        public Manager GetManager() => _managerRepository.GetManager();
        public Manager UpdateManeger(Manager m) => _managerRepository.UpdateManeger(m);
    }
}
