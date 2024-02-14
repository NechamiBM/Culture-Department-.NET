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
    public class WorkerRepository : IWorkerRepository
    {
        private readonly DataContext _context;
        public WorkerRepository(DataContext context) => _context = context;

        public async Task<IEnumerable<Worker>> GetWorkersAsync() => await _context.Workers.ToListAsync();
        public async Task<Worker> GetWorkerAsync(int id) => await _context.Workers.FindAsync(id);
        public async Task<Worker> AddWorkerAsync(Worker w)
        {
            _context.Workers.Add(w);
            await _context.SaveChangesAsync();
            return w;
        }
        public async Task<Worker> UpdateWorkerAsync(int id, Worker w)
        {
            var worker = _context.Workers.Find(id);
            if (worker != null)
            {
                worker.Identity = w.Identity;
                worker.Name = w.Name;
                worker.IsResident = w.IsResident;
            }
            await _context.SaveChangesAsync();
            return w;
        }
        public void DeleteWorker(int id) => _context.Workers.Remove(_context.Workers.ToList().Find(w => w.Id == id));
    }
}
