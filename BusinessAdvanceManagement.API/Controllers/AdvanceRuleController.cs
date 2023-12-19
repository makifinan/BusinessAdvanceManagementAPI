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
    public class AdvanceRuleController : BaseController
    {
        private readonly IAdvanceRuleService _advanceRuleService;

        public AdvanceRuleController(IAdvanceRuleService advanceRuleService)
        {
            _advanceRuleService = advanceRuleService;
        }

        [HttpGet("~/api/getbyroleidrule/{roleID}")]
        public IActionResult GetByRoleID(int roleID)
        {
            var result = _advanceRuleService.GetByRoleID(roleID);
            if (result==null)
            {
                return NotFound();
            }
            if (result.Datas.Any())
            {
                return Ok(result);
            }
            return Ok();
        }
    }
}
