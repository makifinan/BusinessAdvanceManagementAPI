using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.RequestDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Concrete
{
    public class RequestDetailService : IRequestDetailService
    {
        private readonly IRequestDetailDAL _requestDetailDAL;

        public RequestDetailService(IRequestDetailDAL requestDetailDAL)
        {
            _requestDetailDAL = requestDetailDAL;
        }

        public GeneralReturnType<RequestDetailAddDTO> Add(RequestDetailAddDTO requestDetailAddDTO)
        {
            return _requestDetailDAL.Add(requestDetailAddDTO);
        }

        public GeneralReturnType<IEnumerable<ConfirmAdvanceListDTO>> GetAdvanceRequest(int statuID)
        {
            return _requestDetailDAL.GetAdvanceRequest(statuID);
        }

        public GeneralReturnType<IEnumerable<ConfirmAdvanceListDTO>> GetAdvanceRequestAll(int statuID)
        {
           return  _requestDetailDAL.GetAdvanceRequestAll(statuID);
        }

        public GeneralReturnType<IEnumerable<ConfirmAdvanceDetailDTO>> GetAdvanceRequestDetail(int advanceRequestID)
        {
            return _requestDetailDAL.GetAdvanceRequestDetail(advanceRequestID);
        }
    }
}
