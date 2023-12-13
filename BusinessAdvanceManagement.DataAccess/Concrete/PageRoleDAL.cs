using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.PageRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class PageRoleDAL : IPageRolDAL
    {
        private readonly CRUDHelper _crudHelper;

        public PageRoleDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<IEnumerable<PageRoleListDTO>> GetByRolID(int id)
        {
            var query = "select P.PageID,P.PageName from PageRole PR join Page P ON PR.PageID = P.PageID where PR.RoleID=@roleID";
            var parametre = new { roleID=id};
            return _crudHelper.ExecuteQuery<PageRoleListDTO>(query,parametre);
        }
    }
}
