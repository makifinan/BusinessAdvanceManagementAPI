using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.AdvanceRequestDetail
{
    public record AdvanceRequestDetailListDTO
    {
        public int AdvanceRequestDetailID { get; init; }
        public string FristStatuName { get; init; }
        public DateTime CreatedDate { get; init; }
        public string FirstWorkerName { get; init; }
        public string FristWorkerSurname { get; init; }
        public string LastWorkerName { get; init; }
        public string LastWorkerSurname { get; init; }
        public string NextStatuName { get; init; }
        public Decimal ConfimedAmount { get; init; }
    }
}
