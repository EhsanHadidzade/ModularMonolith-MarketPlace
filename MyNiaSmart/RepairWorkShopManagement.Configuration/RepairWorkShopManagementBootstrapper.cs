using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepairWorkShopManagement.Application;
using RepairWorkShopManagement.Application.Contracts.RepainManPanel;
using RepairWorkShopManagement.Application.Contracts.RepairManService;
using RepairWorkShopManagement.Application.Contracts.ServiceTitle;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Application.Contracts.UserImapairmentReport;
using RepairWorkShopManagement.Domain.ImpairmentReportProductAgg;
using RepairWorkShopManagement.Domain.ImpairmentReportServiceAgg;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using RepairWorkShopManagement.Domain.ServiceTitleAgg;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using RepairWorkShopManagement.Domain.UserImapairmentReportAgg;
using RepairWorkShopManagement.Infrastructure.EFCore;
using RepairWorkShopManagement.Infrastructure.EFCore.Repository;
using System;

namespace RepairWorkShopManagement.Configuration
{
    public class RepairWorkShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {

            services.AddTransient<IServiceTitleRepository, ServiceTitleRepository>();
            services.AddTransient<IServiceTitleApplication, ServiceTitleApplication>();

            services.AddTransient<ISystemServiceRepository, SystemServiceRepository>();
            services.AddTransient<ISystemServiceApplication, SystemServiceApplication>();

            services.AddTransient<IRepairManServiceRepository, RepairManServiceRepository>();
            services.AddTransient<IRepairManServiceApplication, RepairManServiceApplication>();

            services.AddTransient<IRepairManPanelRepository, RepairManPanelRepository>();
            services.AddTransient<IRepairManPanelApplication, RepairManPanelApplication>();

            services.AddTransient<IUserImapairmentReportRepository, UserImpairmentReportRepository>();
            services.AddTransient<IUserImpairmentReportApplication, UserImpairmentReportApplication>();

            services.AddTransient<IImpairmentReportServiceRepository, ImpairmentReportServiceRepository>();


            services.AddTransient<IImpairmentReportProductRepository, ImpairmentReportProductRepository>();




            services.AddDbContext<RepairWorkShopContext>(item => item.UseSqlServer(connectionString));

        }
    }
}
