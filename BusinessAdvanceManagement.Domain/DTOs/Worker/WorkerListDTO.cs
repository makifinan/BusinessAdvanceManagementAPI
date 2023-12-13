using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.Worker
{
    public record WorkerListDTO
    {
        public int WorkerID { get; init; }

        public int WorkerRolID { get; init; }
        public string RoleName { get; init; }

        public int WorkerManagerID { get; init; }
        public virtual string ManagerWorkerName { get; init; }
        public virtual string ManagerWorkerSurname { get; init; }
        public int WorkerBirimID { get; init; }
        public string UnitName { get; init; }

        public string WorkerName { get; init; }
        public string WorkerSurname { get; init; }
        public string WorkerEmail { get; init; }
        public string WorkerPasswordHash { get; init; }
        public string WorkerPasswordSalt { get; init; }
    }
}
