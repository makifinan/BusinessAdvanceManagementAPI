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
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("~/api/getallrole")]
        public IActionResult GetAll()
        {
            var result = _roleService.GetAll();
            if (result.Datas.Any())
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
