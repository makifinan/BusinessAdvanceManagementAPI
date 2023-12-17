using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Interface
{
    public interface IAdvanceRequestService
    {
        GeneralReturnType<AdvanceRequestAddDTO> Add(AdvanceRequestAddDTO advanceRequestAddDTO);
        GeneralReturnType<IEnumerable<AdvanceRequestListDTO>> GetByWorker(int workerID);
        GeneralReturnType<IEnumerable<OnlyAdvanceRequestListDTO>> GetByRequestID(int advanceRequestID);
    }
}
