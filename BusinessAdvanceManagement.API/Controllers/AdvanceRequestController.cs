using BusinessAdvanceManagement.API.Controllers.Common;
using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRequest;
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
    public class AdvanceRequestController : BaseController
    {
        private readonly IAdvanceRequestService _advanceRequestService;

        public AdvanceRequestController(IAdvanceRequestService advanceRequestService)
        {
            _advanceRequestService = advanceRequestService;
        }

        [HttpPost("~/api/addadvancerequest")]
        public IActionResult Add(AdvanceRequestAddDTO advanceRequestAddDTO)
        {
            var result = _advanceRequestService.Add(advanceRequestAddDTO);
            if (result.Datas==null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("~/api/getbyworkeradvancerequest/{workerID}")]
        public IActionResult GetByWorker(int workerID)
        {
            var result = _advanceRequestService.GetByWorker(workerID);
            //result null kontrolü yap
            if (result.Datas.Any())
            {
                return Ok(result);
            }
            else
            {
                return Ok();
            }
            
        }
    }
}
