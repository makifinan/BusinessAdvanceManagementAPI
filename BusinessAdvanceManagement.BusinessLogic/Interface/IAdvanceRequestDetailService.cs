using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRequestDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Interface
{
    public interface IAdvanceRequestDetailService
    {
        GeneralReturnType<IEnumerable<AdvanceRequestDetailListDTO>> GetByRequest(int advanceRequestID);
    }
}
