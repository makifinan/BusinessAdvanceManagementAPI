using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Concrete
{
    public class UnitService : IUnitService
    {
        private readonly IUnitDAL _unitDAL;

        public UnitService(IUnitDAL unitDAL)
        {
            _unitDAL = unitDAL;
        }

        public GeneralReturnType<IEnumerable<UnitListDTO>> GetAll()
        {
            return _unitDAL.GetAll();
        }
    }
}
