using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class WorkerDAL : IWorkerDAL
    {
        private readonly CRUDHelper _crudHelper;

        public WorkerDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<IEnumerable<WorkerListDTO>> GetAll()
        {
            var query = "select W.WorkerID,W.WorkerName,W.WorkerSurname,W.WorkerManagerID,W.WorkerBirimID,W.WorkerRolID,W.WorkerEmail,W.WorkerPasswordHash,W.WorkerPasswordSalt,R.RoleName,U.UnitName from Worker W join Role R on  W.WorkerRolID = R.RoleID join Unit U on W.WorkerBirimID = U.UnitID" ;
           return  _crudHelper.ExecuteQuery<WorkerListDTO>(query,"");
        }
    }
}
