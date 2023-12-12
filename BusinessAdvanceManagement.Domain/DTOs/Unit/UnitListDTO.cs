using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.Unit
{
    public record UnitListDTO
    {
        public int UnitID { get; init; }
        public string UnitName { get; set; }
    }
}
