using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Interface
{
    public interface IAdvanceRuleDAL
    {
        GeneralReturnType<IEnumerable<AdvanceRuleListDTO>> GetByRoleID(int roleID);

    }
}
