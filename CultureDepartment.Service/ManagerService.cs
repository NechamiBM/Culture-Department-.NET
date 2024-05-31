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
        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public async Task<Manager> GetManagerAsync()
        {
            var manager = await _managerRepository.GetManagerAsync();
            manager.Password = new string('*', manager.Password.Length);
            return manager;
        }
        public async Task<Manager> UpdateManegerAsync(Manager m) => await _managerRepository.UpdateManegerAsync(m);
        public async Task<bool> IsManagerPassword(string password) => await _managerRepository.IsManagerPassword(password);
    }
}
