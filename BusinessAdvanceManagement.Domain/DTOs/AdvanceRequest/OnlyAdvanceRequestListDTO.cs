using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.AdvanceRequest
{
    public class OnlyAdvanceRequestListDTO
    {
        public int AdvanceRequestID { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public string RoleName { get; set; }
        public string UnitName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DesiredDate { get; set; }
        public string ProjectName { get; set; }
        public decimal Amount { get; set; }
        public decimal ConfirmedAmount { get; set; }
        public string StatuName { get; set; }
        public string Description { get; set; }
        public DateTime DeterminedPaymentDate { get; set; }


    }
}
