using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class ProjectDAL : IProjectDAL
    {
        private readonly CRUDHelper _crudHelper;

        public ProjectDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<IEnumerable<ProjectListDTO>> GetAll()
        {
            var query = "select * from Project";
            return _crudHelper.ExecuteQuery<ProjectListDTO>(query,"");
        }
    }
}
