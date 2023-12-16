using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.RequestDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Interface
{
    public interface IRequestDetailDAL
    {
        GeneralReturnType<IEnumerable<ConfirmAdvanceListDTO>> GetAdvanceRequest(int statuID);
        GeneralReturnType<IEnumerable<ConfirmAdvanceListDTO>> GetAdvanceRequestDetail(int advanceRequestID);
    }
}
