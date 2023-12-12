using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.Worker
{
    public record WorkerListDTO
    {
        public int WorkerID { get; set; }

        public int WorkerRolID { get; set; }
        public string RoleName { get; set; }

        public int WorkerManagerID { get; set; }
        public int WorkerBirimID { get; set; }
        public string UnitName { get; set; }

        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public string WorkerEmail { get; set; }
        public string WorkerPasswordHash { get; set; }
        public string WorkerPasswordSalt { get; set; }
    }
}
