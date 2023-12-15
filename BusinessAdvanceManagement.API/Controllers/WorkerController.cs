using BusinessAdvanceManagement.BusinessLogic.Interface;
using BusinessAdvanceManagement.Domain.DTOs.Worker;
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
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet("~/api/getallworker")]
        public IActionResult GetAll()
        {
            var result = _workerService.GetAll();
            if (result.Datas.Any())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("~/api/addworker")]
        public IActionResult Add(WorkerAddUserDTO workerAddUserDTO)
        {
            var result = _workerService.Add(workerAddUserDTO);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("~/api/login")]
        public IActionResult Login(WorkerLoginDTO workerLoginDTO)
        {
            var result = _workerService.Login(workerLoginDTO);
            if (result!=null)
            {
                //HttpContext.Session.SetString("API_ID", result.WorkerID.ToString());
                //HttpContext.Session.SetString("API_WorkerName", result.WorkerName.ToString());
                //HttpContext.Session.SetString("API_WorkerSurname", result.WorkerSurname.ToString());
                //HttpContext.Session.SetString("API_WorkerRolID", result.WorkerRolID.ToString());
                //HttpContext.Session.SetString("API_WorkerRoleName", result.RoleName.ToString());
                //HttpContext.Session.SetString("API_WorkerManagerID", result.WorkerManagerID.ToString());
                return Ok(result);
            }
            return null;
        }

    }
}
