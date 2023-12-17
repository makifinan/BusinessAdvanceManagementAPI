using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Concrete
{
    public class AdvanceRuleService : IAdvanceRuleService
    {
        private readonly IAdvanceRuleDAL _advanceRuleDAL;

        public AdvanceRuleService(IAdvanceRuleDAL advanceRuleDAL)
        {
            _advanceRuleDAL = advanceRuleDAL;
        }

        public GeneralReturnType<IEnumerable<AdvanceRuleListDTO>> GetByRoleID(int roleID)
        {
            return _advanceRuleDAL.GetByRoleID(roleID);
        }
    }
}
