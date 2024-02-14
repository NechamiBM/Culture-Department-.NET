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
        Task<IEnumerable<Worker>> GetWorkersAsync();
        Task<Worker> GetWorkerAsync(int id);
        Task<Worker> AddWorkerAsync(Worker w);
        Task<Worker> UpdateWorkerAsync(int id, Worker w);
        void DeleteWorker(int id);
    }
}
