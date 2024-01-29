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
    public class WorkerService:IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        public WorkerService(IWorkerRepository workerRepository) => _workerRepository = workerRepository;

        public IEnumerable<Worker> GetWorkers() => _workerRepository.GetWorkers();
        public Worker GetWorker(int id) => _workerRepository.GetWorker(id);
        public Worker AddWorker(Worker w) => _workerRepository.AddWorker(w);
        public Worker UpdateWorker(int id, Worker w) => _workerRepository.UpdateWorker(id, w);
        public void DeleteWorker(int id) => _workerRepository.DeleteWorker(id);
    }
}
