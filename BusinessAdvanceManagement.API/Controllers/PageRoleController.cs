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
    public class PageRoleController : BaseController
    {
        private readonly IPageRoleService _pageRoleService;

        public PageRoleController(IPageRoleService pageRoleService)
        {
            _pageRoleService = pageRoleService;
        }

        [HttpGet("~/api/getbyrolpage/{id}")]
        public IActionResult GetByRolID(int id)
        {
            var result = _pageRoleService.GetByRoleID(id);
            if (result==null)
            {
                return NotFound();
            }
            if (result.Datas.Any())
            {
                return Ok(result);
            }
            return null;
        }

    }
}
