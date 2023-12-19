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
            var query = "WITH NumberedResults AS ( SELECT AdvanceRequestDetailID,S.StatuName AS FirstStatuName,ARD.CreatedDate,W.WorkerName AS FirstWorkerName,W.WorkerSurname AS FirstWorkerSurname,WO.WorkerName AS LastWorkerName,WO.WorkerSurname AS LastWorkerSurname,SA.StatuName AS NextStatuName,ARD.ConfirmedAmount,ROW_NUMBER() OVER(ORDER BY ARD.AdvanceRequestDetailID) AS RowNum FROM advancerequestdetail ARD LEFT JOIN Statu S ON ARD.Status = S.StatuID LEFT JOIN Worker W ON ARD.TransactionOwner = W.WorkerID LEFT JOIN Worker WO ON ARD.NextStageUser = WO.WorkerID LEFT JOIN Statu SA ON ARD.NextStatu = SA.StatuID WHERE ARD.AdvenceRequestID = @advanceRequestid ) SELECT *, RowNum AS CustomAdvanceRequestDetailID FROM NumberedResults ORDER BY AdvanceRequestDetailID ASC; ";
            var parametre = new { advanceRequestid =advanceRequestID};
            return _crudHelper.ExecuteQuery<AdvanceRequestDetailListDTO>(query,parametre);
        }
    }
}
