using Microsoft.EntityFrameworkCore;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using RepairWorkShopManagement.Infrastructure.EFCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore
{
    public class RepairWorkShopContext : DbContext
    {
        public DbSet<SystemService> SystemServices { get; set; }
        public DbSet<RepairManPanel> RepairManPanels { get; set; }
        public DbSet<RepairManService> RepairManServices { get; set; }
        public RepairWorkShopContext(DbContextOptions<RepairWorkShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(SystemServiceMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
