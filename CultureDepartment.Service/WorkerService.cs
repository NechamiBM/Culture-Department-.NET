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
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        public WorkerService(IWorkerRepository workerRepository) => _workerRepository = workerRepository;

        public async Task<IEnumerable<Worker>> GetWorkersAsync() => await _workerRepository.GetWorkersAsync();
        public async Task<Worker> GetWorkerAsync(int id) => await _workerRepository.GetWorkerAsync(id);
        public async Task<Worker> GetWorkerAsync(string identity) => await _workerRepository.GetWorkerAsync(identity);
        public async Task<Worker> AddWorkerAsync(Worker w) => await _workerRepository.AddWorkerAsync(w);
        public async Task<Worker> UpdateWorkerAsync(int id, Worker w) => await _workerRepository.UpdateWorkerAsync(id, w);
        public void DeleteWorker(int id) => _workerRepository.DeleteWorker(id);

    }
}
