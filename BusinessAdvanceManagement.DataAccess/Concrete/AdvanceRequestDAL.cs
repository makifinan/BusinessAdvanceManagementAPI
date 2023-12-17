using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRequest;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class AdvanceRequestDAL : IAdvanceRequestDAL
    {
        private readonly CRUDHelper _crudHelper;

        public AdvanceRequestDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<AdvanceRequestAddDTO> Add(AdvanceRequestAddDTO advanceRequestAddDTO)
        {
            //httpcontext.session gelmedi bak buraya
            var parametre = new { AdvanceRequestStatus = advanceRequestAddDTO.AdvanceRequestStatus,Amount=advanceRequestAddDTO.Amount,CreatedDate=DateTime.Now,DesiredDate=advanceRequestAddDTO.DesiredDate,ProjectID=advanceRequestAddDTO.ProjectID,Description=advanceRequestAddDTO.Description,WorkerID=advanceRequestAddDTO.WorkerID,NextStageUser=advanceRequestAddDTO.NextStageUser,NextStatu=advanceRequestAddDTO.NextStatu,FirstStatus=1 };

            return _crudHelper.ExecuteStoreProcedure<AdvanceRequestAddDTO>("SP_AdvanceRequestAdd", parametre, advanceRequestAddDTO);
        }

        public GeneralReturnType<IEnumerable<OnlyAdvanceRequestListDTO>> GetByRequestID(int advanceRequestID)
        {
            var query = "select AR.AdvanceRequestID ,W.WorkerName,W.WorkerSurname,R.RoleName,U.UnitName,AR.CreatedDate,AR.DesiredDate,P.ProjectName,AR.Amount,AR.ConfirmedAmount,S.StatuName,AR.Description,Ar.DeterminedPaymentDate from AdvanceRequest AR join Worker W ON AR.WorkerID = W.WorkerID JOIN ROLE R ON W.WorkerRolID = R.RoleID JOIN Unit U ON W.WorkerBirimID = U.UnitID JOIN Project P ON AR.ProjectID = P.ProjectID JOIN Statu S ON AR.AdvanceRequestStatus = S.StatuID WHERE AR.AdvanceRequestID = @advanceRequest";

            var parametre = new { advanceRequest=advanceRequestID};
            return _crudHelper.ExecuteQuery<OnlyAdvanceRequestListDTO>(query,parametre);
        }

        public GeneralReturnType<IEnumerable<AdvanceRequestListDTO>> GetByWorker(int workerID)
        {
            var query = "select * from AdvanceRequest AR left join Statu S on AR.AdvanceRequestStatus = S.StatuID left join Worker W on AR.ApprovingDisapproving = W.WorkerID left join Role R on AR.ApprovingDisapprovingRole = R.RoleID left join RefundStatus RS on AR.RefundStatus = RS.RefoundStatusID left join Project P on AR.ProjectID = P.ProjectID where Ar.WorkerID =@workerID";

            var parametre = new { workerID=workerID};

            return _crudHelper.ExecuteQuery<AdvanceRequestListDTO>(query,parametre);
        }

        
    }
}
