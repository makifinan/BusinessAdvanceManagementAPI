using BusinessAdvanceManagement.API.Controllers.Common;
using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Domain.DTOs.RequestDetail;
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
    public class RequestDetailController : BaseController
    {
        private readonly IRequestDetailService _requestDetailService;

        public RequestDetailController(IRequestDetailService requestDetailService)
        {
            _requestDetailService = requestDetailService;
        }

        [HttpGet("~/api/getadvancerequest/{statuID}")]
        public IActionResult GetAdvanceRequest(int statuID)
        {
            var result = _requestDetailService.GetAdvanceRequestAll(statuID);
            if (result.Datas.Any())
            {
                return Ok(result);
            }
            return Ok();
        }

        [HttpGet("~/api/getadvancerequestdetail/{advanceRequestID}")]
        public IActionResult GetAdvanceRequestDetail(int advanceRequestID)
        {
            var result = _requestDetailService.GetAdvanceRequestDetail(advanceRequestID);
            if (result.Datas.Any())
            {
                return Ok(result);
            }
            return Ok();
        }

        [HttpPost("~/api/addrequestdetail")]
        public IActionResult Add(RequestDetailAddDTO requestDetailAddDTO)
        {
            var result = _requestDetailService.Add(requestDetailAddDTO);
            if (result.Datas==null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
