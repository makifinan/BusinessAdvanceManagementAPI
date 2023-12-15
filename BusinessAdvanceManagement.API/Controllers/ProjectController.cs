using BusinessAdvanceManagement.API.Controllers.Common;
using BusinessAdvanceManagement.BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("~/api/getallproject")]
        public IActionResult GetAll()
        {
            var result = _projectService.GetAll();
            if (result.Datas.Any())
            {
                return Ok(result);
            }
            return null;
        }
    }
}
