using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Interface
{
    public interface IRoleService
    {
        GeneralReturnType<IEnumerable<RoleListDTO>> GetAll();
        
    }
}
