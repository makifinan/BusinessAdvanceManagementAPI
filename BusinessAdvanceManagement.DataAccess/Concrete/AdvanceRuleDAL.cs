using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class AdvanceRuleDAL : IAdvanceRuleDAL
    {
        CRUDHelper _crudHelper;

        public AdvanceRuleDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<IEnumerable<AdvanceRuleListDTO>> GetByRoleID(int roleID)
        {
            var query = "select * from AdvanceRule where RoleID=@rolID";
            var parametre = new { rolID=roleID};

            return _crudHelper.ExecuteQuery<AdvanceRuleListDTO>(query,parametre);
        }
    }
}
