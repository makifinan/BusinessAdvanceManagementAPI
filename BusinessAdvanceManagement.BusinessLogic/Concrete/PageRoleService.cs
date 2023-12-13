using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.PageRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Concrete
{
    public class PageRoleService : IPageRoleService
    {
        private readonly IPageRolDAL _pageRolDAL;

        public PageRoleService(IPageRolDAL pageRolDAL)
        {
            _pageRolDAL = pageRolDAL;
        }

        public GeneralReturnType<IEnumerable<PageRoleListDTO>> GetByRoleID(int id)
        {
            return _pageRolDAL.GetByRolID(id);
        }
    }
}
