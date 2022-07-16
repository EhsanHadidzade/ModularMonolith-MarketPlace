using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepairWorkShopManagement.Application;
using RepairWorkShopManagement.Application.Contracts.RepainManPanel;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
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

            services.AddTransient<IRepairManPanelRepository, RepairManPanelRepository>();
            services.AddTransient<IRepairManPanelApplication, RepairManPanelApplication>();


            services.AddDbContext<RepairWorkShopContext>(item => item.UseSqlServer(connectionString));

        }
    }
}
