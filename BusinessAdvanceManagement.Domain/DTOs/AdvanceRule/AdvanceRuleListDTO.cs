using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.AdvanceRule
{
    public class AdvanceRuleListDTO
    {
        public int AdvanceRuleID { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int RoleID { get; set; }

    }
}
