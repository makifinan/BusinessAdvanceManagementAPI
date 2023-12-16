using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.RequestDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class RequestDetailDAL : IRequestDetailDAL
    {
        private readonly CRUDHelper _crudHelper;

        public RequestDetailDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<IEnumerable<ConfirmAdvanceListDTO>> GetAdvanceRequest(int statuID)
        {
            var query = "select AR.AdvanceRequestID, ar.AdvanceRequestStatus,W.WorkerName,W.WorkerSurname,R.RoleName,U.UnitName,S.StatuName,AR.Amount,AR.CreatedDate,AR.DesiredDate,P.ProjectName from AdvanceRequest AR join Worker W on AR.WorkerID = W.WorkerID join Role R ON W.WorkerRolID = R.RoleID join Unit U on W.WorkerBirimID = U.UnitID join Statu S on AR.AdvanceRequestStatus = S.StatuID join Project P on AR.ProjectID = P.ProjectID WHERE AdvanceRequestStatus = @advanceRequestStatus";
            var parametre = new { advanceRequestStatus =statuID};
            return _crudHelper.ExecuteQuery<ConfirmAdvanceListDTO>(query,parametre);
        }

        public GeneralReturnType<IEnumerable<ConfirmAdvanceListDTO>> GetAdvanceRequestDetail(int advanceRequestID)
        {
            throw new NotImplementedException();
        }
    }
}
