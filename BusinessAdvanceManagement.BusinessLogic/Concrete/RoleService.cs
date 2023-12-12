using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IRoleDAL _roleDAL;

        public RoleService(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        public GeneralReturnType<IEnumerable<RoleListDTO>> GetAll()
        {
            return _roleDAL.GetAll();
        }
    }
}
