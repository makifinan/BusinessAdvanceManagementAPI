using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class UnitDAL : IUnitDAL
    {
        CRUDHelper _crudHelper;

        public UnitDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<IEnumerable<UnitListDTO>> GetAll()
        {
            var query = "Select * from Unit";
            
            var result = _crudHelper.ExecuteQuery<UnitListDTO>(query,"") ;
            return result;
        }
    }
}
