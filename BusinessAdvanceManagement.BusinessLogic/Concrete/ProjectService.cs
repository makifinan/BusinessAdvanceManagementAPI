using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.Concrete
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectDAL _projectDAL;

        public ProjectService(IProjectDAL projectDAL)
        {
            _projectDAL = projectDAL;
        }

        public GeneralReturnType<IEnumerable<ProjectListDTO>> GetAll()
        {
            return _projectDAL.GetAll();
        }
    }
}
