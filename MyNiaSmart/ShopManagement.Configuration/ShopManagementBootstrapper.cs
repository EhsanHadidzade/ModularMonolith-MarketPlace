using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Application.Contract.ProductStatus;
using ShopManagement.Application.Contract.ProductUsageType;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductBrandAgg;
using ShopManagement.Domain.ProductModelAgg;
using ShopManagement.Domain.ProductStatusAgg;
using ShopManagement.Domain.ProductTypeAgg;
using ShopManagement.Domain.ProductUsageTypeAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionstring)
        {

            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<IProductTypeApplication, ProductTypeApplication>();

            services.AddTransient<IProductUsageTypeRepository, ProductUsageTypeRepository>();
            services.AddTransient<IProductUsageTypeApplication,ProductUsageTypeApplication>();

            services.AddTransient<IProductStatusRepository, ProductStatusRepository>();
            services.AddTransient<IProductStatusApplication, ProductStatusApplication>();

            services.AddTransient<IProductModelRepository, ProductModelRepository>();
            services.AddTransient<IProductModelApplication, ProductModelApplication>();

            services.AddTransient<IProductBrandRepository, ProductBrandRepository>();
            services.AddTransient<IProductBrandApplication, ProductBrandApplication>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductApplication, ProductApplication>();


            services.AddDbContext<ShopContext>(item => item.UseSqlServer(connectionstring));
        }
    }
}
