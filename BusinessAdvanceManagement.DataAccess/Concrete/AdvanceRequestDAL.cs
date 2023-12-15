using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.AdvanceRequest;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class AdvanceRequestDAL : IAdvanceRequestDAL
    {
        private readonly CRUDHelper _crudHelper;

        public AdvanceRequestDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<AdvanceRequestAddDTO> Add(AdvanceRequestAddDTO advanceRequestAddDTO)
        {
            //httpcontext.session gelmedi bak buraya
            var parametre = new { AdvanceRequestStatus = 1,Amount=advanceRequestAddDTO.Amount,CreatedDate=DateTime.Now,DesiredDate=advanceRequestAddDTO.DesiredDate,ProjectID=advanceRequestAddDTO.ProjectID,Description=advanceRequestAddDTO.Description,WorkerID=advanceRequestAddDTO.WorkerID,NextStageUser=advanceRequestAddDTO.NextStageUser,NextStatu=advanceRequestAddDTO.NextStatu,FirstStatus=1 };

            return _crudHelper.ExecuteStoreProcedure<AdvanceRequestAddDTO>("SP_AdvanceRequestAdd", parametre, advanceRequestAddDTO);
        }
    }
}
