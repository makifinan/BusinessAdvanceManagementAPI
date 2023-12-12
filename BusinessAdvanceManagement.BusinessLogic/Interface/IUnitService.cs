using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Domain.DTOs.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Interface
{
    public interface IUnitService
    {
        GeneralReturnType<IEnumerable<UnitListDTO>> GetAll();
    }
}
