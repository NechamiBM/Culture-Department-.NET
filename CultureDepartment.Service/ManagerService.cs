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
            manager.Password = "********";//צריך לבדוק איך להחליף לכוכביות
            return manager;
        }
        public async Task<Manager> UpdateManegerAsync(Manager m) => await _managerRepository.UpdateManegerAsync(m);
    }
}
