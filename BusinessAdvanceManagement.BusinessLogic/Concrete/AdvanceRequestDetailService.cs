using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRequestDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Concrete
{
    public class AdvanceRequestDetailService : IAdvanceRequestDetailService
    {
        private readonly IAdvanceRequestDetailDAL _advanceRequestDetailDAL;

        public AdvanceRequestDetailService(IAdvanceRequestDetailDAL advanceRequestDetailDAL)
        {
            _advanceRequestDetailDAL = advanceRequestDetailDAL;
        }

        public GeneralReturnType<IEnumerable<AdvanceRequestDetailListDTO>> GetByRequest(int advanceRequestID)
        {
           return _advanceRequestDetailDAL.GetByRequest(advanceRequestID);
        }
    }
}
