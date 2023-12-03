using CultureDepartment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Core.Repositories
{
    public interface IWorkerRepository
    {
        public IEnumerable<Worker> GetWorkers();
        public Worker GetWorker(int id);
        public void AddWorker(Worker w);
        public bool UpdateWorker(int id,Worker w);
        public void DeleteWorker(int id);
    }
}
