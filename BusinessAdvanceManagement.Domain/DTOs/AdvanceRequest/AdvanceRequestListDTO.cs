using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.AdvanceRequest
{
    public record AdvanceRequestListDTO
    {
        public int AdvanceRequestID { get; set; }
        public int AdvanceRequestStatus { get; set; }
        public string StatuName { get; set; }

        public int ApprovingDisapproving { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }

        public DateTime ApprovalRejectionDate { get; set; }
        public decimal ConfirmedAmount { get; set; }
        public DateTime DeterminedPaymentDate { get; set; }
        public DateTime PaymentMadeDate { get; set; }

        public int RefoundStatus { get; set; }
        public string StatusName { get; set; }

        public int ApprovingDisapprovingRole { get; set; }
        public string RoleName { get; set; }

        public int WorkerID { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Amount { get; set; }

        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public DateTime DesiredDate { get; set; }
        public string Description { get; set; }
        public int FirstStatus { get; set; }
        public int NextStageUser { get; set; }
        public int NextStatu { get; set; }
        public int WorkerManagerID { get; set; }
    }
}
