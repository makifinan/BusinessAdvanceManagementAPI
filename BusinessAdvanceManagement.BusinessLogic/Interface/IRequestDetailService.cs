using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.RequestDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Interface
{
    public interface IRequestDetailService
    {
        GeneralReturnType<IEnumerable<ConfirmAdvanceListDTO>> GetAdvanceRequest(int statuID);
        GeneralReturnType<IEnumerable<ConfirmAdvanceListDTO>> GetAdvanceRequestAll(int statuID);
        GeneralReturnType<IEnumerable<ConfirmAdvanceDetailDTO>> GetAdvanceRequestDetail(int advanceRequestID);
        GeneralReturnType<RequestDetailAddDTO> Add(RequestDetailAddDTO requestDetailAddDTO);
        GeneralReturnType<RequestDetailAddDTO> Red(RequestDetailAddDTO requestDetailAddDTO);
    }
}
