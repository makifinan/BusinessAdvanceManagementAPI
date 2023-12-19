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

        public GeneralReturnType<RequestDetailAddDTO> Add(RequestDetailAddDTO requestDetailAddDTO)
        {
            var query = "insert into AdvanceRequestDetail (AdvenceRequestID,Status,CreatedDate,TransactionOwner,ConfirmedAmount,NextStageUser,NextStatu) values (@advanceRequestID,@statuID,@createdDate,@transactionOwner,@confirmedAmount,@nextStageUser,@nextStatu)";

            var parametre = new { advanceRequestID =requestDetailAddDTO.AdvanceRequestID,statuID=requestDetailAddDTO.StatuID, createdDate=DateTime.Now,transactionOwner=requestDetailAddDTO.TransactionOwner, confirmedAmount =requestDetailAddDTO.ConfirmAmount,nextStageUser=requestDetailAddDTO.NextStageUser,nextStatu=requestDetailAddDTO.NextStatu};
            
            var firstProcess=_crudHelper.ExecuteNonQuery<RequestDetailAddDTO>(query, parametre, requestDetailAddDTO);

            if (requestDetailAddDTO.ApprovingDisapproving>0 && requestDetailAddDTO.ApprovingDisapprovingRole>0)
            {
                var successquery = "update AdvanceRequest set AdvanceRequestStatus=@statu,ApprovingDisapproving=@approvingDisapproving,ApprovalRejectionDate=@approvalRejectionDate,ConfirmedAmount=@confirmAmount,ApprovingDisapprovingRole=@approvingDisapprovinRole where AdvanceRequestID=@advanceRequestID";

                var successParametre = new { statu = requestDetailAddDTO.RequestStatuID, approvingDisapproving = requestDetailAddDTO.ApprovingDisapproving, approvalRejectionDate = DateTime.Now, confirmAmount = requestDetailAddDTO.ConfirmAmount, approvingDisapprovinRole = requestDetailAddDTO.ApprovingDisapprovingRole, advanceRequestID = requestDetailAddDTO.AdvanceRequestID };

                var result = _crudHelper.ExecuteNonQuery<RequestDetailAddDTO>(successquery, successParametre, requestDetailAddDTO);
            }
            else if (requestDetailAddDTO.DeterminedPaymentDate != DateTime.MinValue)
            {
                //fm insert yapiyor
                var successquery = "update AdvanceRequest set AdvanceRequestStatus=@statu,DeterminedPaymentDate=@determinedPaymentDate where AdvanceRequestID=@advanceRequestID";

                var successParametre = new { statu = requestDetailAddDTO.RequestStatuID,determinedPaymentDate=requestDetailAddDTO.DeterminedPaymentDate, advanceRequestID = requestDetailAddDTO.AdvanceRequestID };

                var result = _crudHelper.ExecuteNonQuery<RequestDetailAddDTO>(successquery, successParametre, requestDetailAddDTO);
            }
            else
            {
                var query2 = "update AdvanceRequest set AdvanceRequestStatus=@statu,ConfirmedAmount=@confirmAmount where AdvanceRequestID=@advanceRequestID ";

                var parametre2 = new { statu = requestDetailAddDTO.RequestStatuID, confirmAmount = requestDetailAddDTO.ConfirmAmount, advanceRequestID = requestDetailAddDTO.AdvanceRequestID };

                var result = _crudHelper.ExecuteNonQuery<RequestDetailAddDTO>(query2, parametre2, requestDetailAddDTO);
            }


            return firstProcess;
        }

        public GeneralReturnType<RequestDetailAddDTO> Red(RequestDetailAddDTO requestDetailAddDTO)
        {
            var query = "update AdvanceRequest set AdvanceRequestStatus=@status,ApprovingDisapproving=@approvingDisapproving,ApprovalRejectionDate=@approvalRejectionDate,ApprovingDisapprovingRole=@approvingDisapprovingRole where AdvanceRequestID=@advanceRequestID";

            var parametre = new { status=requestDetailAddDTO.StatuID,approvingDisapproving=requestDetailAddDTO.ApprovingDisapproving, approvalRejectionDate=DateTime.Now,approvingDisapprovingRole=requestDetailAddDTO.ApprovingDisapprovingRole,advanceRequestID=requestDetailAddDTO.AdvanceRequestID};

            return _crudHelper.ExecuteNonQuery<RequestDetailAddDTO>(query,parametre,requestDetailAddDTO);
        }

        public GeneralReturnType<IEnumerable<ConfirmAdvanceListDTO>> GetAdvanceRequest(int statuID)
        {
            var query = "select AR.AdvanceRequestID, ar.AdvanceRequestStatus,W.WorkerName,W.WorkerSurname,R.RoleName,U.UnitName,S.StatuName,AR.Amount,AR.CreatedDate,AR.DesiredDate,P.ProjectName from AdvanceRequest AR join Worker W on AR.WorkerID = W.WorkerID join Role R ON W.WorkerRolID = R.RoleID join Unit U on W.WorkerBirimID = U.UnitID join Statu S on AR.AdvanceRequestStatus = S.StatuID join Project P on AR.ProjectID = P.ProjectID WHERE AdvanceRequestStatus = @advanceRequestStatus";
            var parametre = new { advanceRequestStatus =statuID};
            return _crudHelper.ExecuteQuery<ConfirmAdvanceListDTO>(query,parametre);
        }

        public GeneralReturnType<IEnumerable<ConfirmAdvanceListDTO>> GetAdvanceRequestAll(int statuID)
        {
            var query = "WITH RankedResults AS ( SELECT AR.AdvanceRequestID, ARD.AdvanceRequestDetailID, WO.WorkerName, WO.WorkerSurname, RO.RoleName, U.UnitName, S.StatuName,AR.Amount,AR.CreatedDate,AR.DesiredDate,P.ProjectName,W.WorkerName AS EndConfirmWorkerName,W.WorkerSurname AS EndConfirmWorkerSurname,R.RoleName AS EndConfirmRoleName, ARD.CreatedDate AS EndConfirmDate,ARD.ConfirmedAmount AS EndConfirmAmount,ROW_NUMBER() OVER(PARTITION BY AR.AdvanceRequestID ORDER BY ARD.CreatedDate DESC) AS RowNum FROM AdvanceRequestDetail ARD JOIN Worker W ON ARD.TransactionOwner = W.WorkerID JOIN Role R ON W.WorkerRolID = R.RoleID JOIN AdvanceRequest AR ON ARD.AdvenceRequestID = AR.AdvanceRequestID JOIN Worker WO ON AR.WorkerID = WO.WorkerID JOIN Role RO ON WO.WorkerRolID = RO.RoleID JOIN Unit U ON WO.WorkerBirimID = U.UnitID JOIN Statu S ON AR.AdvanceRequestStatus = S.StatuID JOIN Project P ON AR.ProjectID = P.ProjectID WHERE AR.AdvanceRequestStatus = @advanceRequestStatus ) SELECT AdvanceRequestID,AdvanceRequestDetailID,WorkerName,WorkerSurname,RoleName,   UnitName,StatuName,Amount,CreatedDate,DesiredDate,ProjectName,EndConfirmWorkerName,EndConfirmWorkerSurname,EndConfirmRoleName,EndConfirmDate,EndConfirmAmount FROM RankedResults WHERE RowNum = 1";

            var parametre = new { advanceRequestStatus = statuID };
            return _crudHelper.ExecuteQuery<ConfirmAdvanceListDTO>(query,parametre);
        }

        public GeneralReturnType<IEnumerable<ConfirmAdvanceDetailDTO>> GetAdvanceRequestDetail(int advanceRequestID)
        {
            var query = "select top 1 ARD.AdvanceRequestDetailID,W.WorkerName AS EndConfirmWorkerName,W.WorkerSurname as EndConfirmWorkerSurname,R.RoleName as EndConfirmRoleName,ARD.CreatedDate as EndConfirmDate,ARD.ConfirmedAmount as EndConfirmAmount from AdvanceRequestDetail ARD join Worker W on ARD.TransactionOwner = W.WorkerID join Role R on W.WorkerRolID = R.RoleID WHERE ARD.AdvenceRequestID = @advenceRequestID ORDER BY ARD.CreatedDate DESC";

            var parametre = new { advenceRequestID=advanceRequestID};

            return  _crudHelper.ExecuteQuery<ConfirmAdvanceDetailDTO>(query,parametre);
        }
    }
}
