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
        public Manager GetManager() => _context.Manager;
        

        public void UpdateManeger(Manager m)
        {
            _context.Manager.TZ = m.TZ;
            _context.Manager.FirstName = m.FirstName;
            _context.Manager.LastName = m.LastName;
            _context.Manager.IsResident = m.IsResident;
            _context.Manager.Password = m.Password;
        }
    }

}
