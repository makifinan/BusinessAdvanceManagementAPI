using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.RequestDetail
{
    public record ConfirmAdvanceDetailDTO
    {
        public int AdvanceRequestDetailID { get; set; }
        public string EndConfirmWorkerName { get; set; }
        public string EndConfirmWorkerSurname { get; set; }
        public string EndConfirmRoleName { get; set; }
        public DateTime EndConfirmDate { get; set; }
        public decimal EndConfirmAmount { get; set; }
    }
}
