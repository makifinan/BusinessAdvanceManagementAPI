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
    public class AdvanceRequestDetailController : BaseController
    {
        private readonly IAdvanceRequestDetailService _advanceRequestDetailService;

        public AdvanceRequestDetailController(IAdvanceRequestDetailService advanceRequestDetailService)
        {
            _advanceRequestDetailService = advanceRequestDetailService;
        }

        [HttpGet("~/api/getbyrequest/{advanceRequestID}")]
        public IActionResult GetByRequest(int advanceRequestID)
        {
            var result = _advanceRequestDetailService.GetByRequest(advanceRequestID);
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
