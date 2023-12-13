using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.Worker
{
    public record WorkerLoginDTO
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
