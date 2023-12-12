using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Interface
{
    public interface IUnitDAL
    {
        GeneralReturnType<IEnumerable<UnitListDTO>> GetAll();
    }
}
