using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Concrete
{
    public class AdvanceRequestService : IAdvanceRequestService
    {
        private readonly IAdvanceRequestDAL _advanceRequestDAL;

        public AdvanceRequestService(IAdvanceRequestDAL advanceRequestDAL)
        {
            _advanceRequestDAL = advanceRequestDAL;
        }

        public GeneralReturnType<AdvanceRequestAddDTO> Add(AdvanceRequestAddDTO advanceRequestAddDTO)
        {
            return _advanceRequestDAL.Add(advanceRequestAddDTO);
        }

        public GeneralReturnType<IEnumerable<AdvanceRequestListsDTO>> GetByApproving(int statuID)
        {
            return _advanceRequestDAL.GetByApproving(statuID);
        }

        public GeneralReturnType<IEnumerable<OnlyAdvanceRequestListDTO>> GetByRequestID(int advanceRequestID)
        {
            return _advanceRequestDAL.GetByRequestID(advanceRequestID);
        }

        public GeneralReturnType<IEnumerable<AdvanceRequestListDTO>> GetByWorker(int workerID)
        {
           return _advanceRequestDAL.GetByWorker(workerID);
        }
    }
}
