using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.PageRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Interface
{
    public interface IPageRoleService
    {
        GeneralReturnType<IEnumerable<PageRoleListDTO>> GetByRoleID(int id);
    }
}
