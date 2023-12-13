using BusinessAdvanceManagement.BusinessLogic.Concrete;
using BusinessAdvanceManagement.BusinessLogic.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.BusinessLogic.ServiceRegistration
{
    public static class ServiceBusinessRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IWorkerService, WorkerService>();


            return services;
        }
    }
}
