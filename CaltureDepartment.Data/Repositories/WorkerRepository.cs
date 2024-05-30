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
        public async Task<Worker> GetWorkerAsync(string identity) => await _context.Workers.FirstOrDefaultAsync(t => t.Identity == identity);
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
            return worker;
        }
        public void DeleteWorker(int id)
        {
            var workerToDelete = _context.Workers.Find(id);
            if (workerToDelete != null)
                _context.Workers.Remove(workerToDelete);
            _context.SaveChanges();
        }
    }
}
