using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Interface
{
    public interface IAdvanceRequestDAL
    {
        GeneralReturnType<AdvanceRequestAddDTO> Add(AdvanceRequestAddDTO advanceRequestAddDTO);
        GeneralReturnType<IEnumerable<AdvanceRequestListDTO>> GetByWorker(int workerID);
    }
}
