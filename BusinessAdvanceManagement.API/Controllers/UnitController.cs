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
    public class UnitController : BaseController
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet("~/api/getallunit")]
        public IActionResult GetAll()
        {
            var result = _unitService.GetAll();
            if (result.Datas.Any())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

    }
}
