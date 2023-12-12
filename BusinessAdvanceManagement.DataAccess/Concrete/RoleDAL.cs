using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class RoleDAL : IRoleDAL
    {
        private readonly CRUDHelper _crudHelper;

        public RoleDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<IEnumerable<RoleListDTO>> GetAll()
        {
            var query = "Select * from Role";
            return _crudHelper.ExecuteQuery<RoleListDTO>(query,"");
        }
    }
}
