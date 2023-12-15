using BusinessAdvanceManagement.Core.Helpers.Connection;
using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.DataAccess.Concrete;
using BusinessAdvanceManagement.DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ConnectionHelper>();
            services.AddScoped<CRUDHelper>();
            services.AddScoped<IUnitDAL,UnitDAL>();
            services.AddScoped<IRoleDAL,RoleDAL>();
            services.AddScoped<IWorkerDAL,WorkerDAL>();
            services.AddScoped<IPageRolDAL,PageRoleDAL>();
            services.AddScoped<IAdvanceRequestDAL,AdvanceRequestDAL>();
            services.AddScoped<IProjectDAL,ProjectDAL>();
            
            


            return services;
        }
    }
}
