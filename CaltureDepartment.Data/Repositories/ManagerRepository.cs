using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Repositories;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaltureDepartment.Data.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly DataContext _context;
        public ManagerRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Manager> GetManagerAsync() => await _context.Manager.FirstOrDefaultAsync();
        public async Task<Manager> UpdateManegerAsync(Manager m)
        {
            var manager = _context.Manager.FirstOrDefault();
            if (manager != null)
            {
                manager.Identity = m.Identity;
                manager.Password = m.Password;
                manager.Name = m.Name;
            }
            await _context.SaveChangesAsync();
            return manager;
        }
        public async Task<bool> IsManagerPassword(string password)
        {
            var m = await _context.Manager.FirstOrDefaultAsync();
            return m == null || m.Password == password;
        }
    }
}
