using CultureDepartment.Core.Entities;
using CultureDepartment.Core.Repositories;
using CultureDepartment.Data;
using Microsoft.AspNetCore.Mvc;
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
        public Manager GetManager() => _context.Manager.FirstOrDefault();
        public Manager UpdateManeger(Manager m)
        {
            var manager = _context.Manager.FirstOrDefault();
            if (manager != null)
            {
                manager.Identity = m.Identity;
                manager.Password = m.Password;
                manager.Name = m.Name;
            }
            _context.SaveChanges();
            return m;
        }
    }

}
