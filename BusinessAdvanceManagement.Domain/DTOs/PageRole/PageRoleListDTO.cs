using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.PageRole
{
    public record PageRoleListDTO
    {
        public int PageID { get; set; }
        public string PageName { get; set; }
    }
}
