using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Interface
{
    public interface IWorkerDAL
    {
        GeneralReturnType<IEnumerable<WorkerListDTO>> GetAll();
        GeneralReturnType<WorkerAddDTO> Add(WorkerAddUserDTO workerAddUserDTO);
        WorkerListDTO Login(WorkerLoginDTO workerLoginDTO);
        
    }
}
