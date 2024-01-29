using CultureDepartment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Core.Services
{
    public interface IWorkerService
    {
        public IEnumerable<Worker> GetWorkers();
        public Worker GetWorker(int id);
        public Worker AddWorker(Worker w);
        public Worker UpdateWorker(int id,Worker w);
        public void DeleteWorker(int id);
    }
}
