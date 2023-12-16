using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.RequestDetail
{
    public record ConfirmAdvanceListDTO
    {
        public int AdvanceRequestID { get; set; }
        public int AdvanceRequestDetailID { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public string RoleName { get; set; }
        public string UnitName { get; set; }
        public string Amount { get; set; }
        public DateTime CreadtedDate { get; set; }
        public DateTime DesiredDate { get; set; }
        public string ProjectName { get; set; }
        public string EndConfirmWorkerName { get; set; }
        public string EndConfirmWorkerSurname { get; set; }
        public string EndConfirmRoleName { get; set; }
        public DateTime EndConfirmDate { get; set; }
        public decimal EndConfirmAmount { get; set; }
    }
}
