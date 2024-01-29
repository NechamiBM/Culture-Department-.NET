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
    public class WorkerRepository : IWorkerRepository
    {
        private readonly DataContext _context;
        public WorkerRepository(DataContext context) => _context = context;

        public IEnumerable<Worker> GetWorkers()=> _context.Workers;
        public Worker GetWorker(int id)=> _context.Workers.Find(id);
        public Worker AddWorker(Worker w)
        {
            _context.Workers.Add(w);
            _context.SaveChanges();
            return w;
        }
        public Worker UpdateWorker(int id, Worker w)
        {
            var worker = _context.Workers.Find(id);
            if (worker != null)
            {
                worker.Identity = w.Identity;
                worker.Name = w.Name;
                worker.IsResident = w.IsResident;
            }
            _context.SaveChanges();
            return w;
        }
        public void DeleteWorker(int id)=> _context.Workers.Remove(_context.Workers.ToList().Find(w => w.Id == id));
    }
}
