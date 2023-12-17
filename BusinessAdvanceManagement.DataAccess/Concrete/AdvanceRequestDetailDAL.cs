using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRequestDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class AdvanceRequestDetailDAL : IAdvanceRequestDetailDAL
    {
        private readonly CRUDHelper _crudHelper;

        public AdvanceRequestDetailDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<IEnumerable<AdvanceRequestDetailListDTO>> GetByRequest(int advanceRequestID)
        {
            var query = "select ARD.AdvanceRequestDetailID,S.StatuName as FirstStatuName,ARD.CreatedDate,W.WorkerName as FirstWorkerName,W.WorkerSurname as FirstWorkerSurname,WO.WorkerName AS LastWorkerName,WO.WorkerSurname as LastWorkerSurname,SA.StatuName as NextStatuName,ARD.ConfirmedAmount from advancerequestdetail ARD left join Statu S on ARD.Status = S.StatuID LEFT JOIN Worker W on ARD.TransactionOwner = W.WorkerID left join Worker WO on ARD.NextStageUser = WO.WorkerID LEFT JOIN Statu SA on ARD.NextStatu = SA.StatuID WHERE ARD.AdvenceRequestID = @advanceRequestid ORDER BY ARD.AdvanceRequestDetailID ASC";
            var parametre = new { advanceRequestid =advanceRequestID};
            return _crudHelper.ExecuteQuery<AdvanceRequestDetailListDTO>(query,parametre);
        }
    }
}
