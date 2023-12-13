using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Concrete
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerDAL _workerDAL;

        public WorkerService(IWorkerDAL workerDAL)
        {
            _workerDAL = workerDAL;
        }

        public GeneralReturnType<IEnumerable<WorkerListDTO>> GetAll()
        {
            return _workerDAL.GetAll();
        }

        public GeneralReturnType<WorkerAddDTO> Add(WorkerAddUserDTO workerAddUserDTO)
        {
            return _workerDAL.Add(workerAddUserDTO); ;
        }

    }
}
