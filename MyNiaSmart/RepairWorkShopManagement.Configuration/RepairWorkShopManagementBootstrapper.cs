using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepairWorkShopManagement.Application;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using RepairWorkShopManagement.Infrastructure.EFCore;
using RepairWorkShopManagement.Infrastructure.EFCore.Repository;
using System;

namespace RepairWorkShopManagement.Configuration
{
    public  class RepairWorkShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {

            services.AddTransient<ISystemServiceRepository, SystemServiceRepository>();
            services.AddTransient<ISystemServiceApplication, SystemServiceApplication>();


            services.AddDbContext<RepairWorkShopContext>(item => item.UseSqlServer(connectionString));

        }
    }
}
