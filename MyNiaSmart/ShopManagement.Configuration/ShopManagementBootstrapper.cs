using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory.ProductBrand;
using ShopManagement.Application.Contract.ProductCategory.ProductModel;
using ShopManagement.Application.Contract.ProductCategory.ProductStatus;
using ShopManagement.Application.Contract.ProductCategory.ProductType;
using ShopManagement.Application.Contract.ProductCategory.ProductUsageType;
using ShopManagement.Application.Contract.SellerPanel;
using ShopManagement.Application.Contract.SellerProduct;
using ShopManagement.Application.Contract.SellerProductMedia;
using ShopManagement.Application.ProductCategoryApplication;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductModelAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductStatusAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductTypeAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductUsageTypeAgg;
using ShopManagement.Domain.SellerPanelAgg;
using ShopManagement.Domain.SellerProductAgg;
using ShopManagement.Domain.SellerProductMediaAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;
using ShopManagement.Infrastructure.EFCore.Repository.ProductCategoryRepository;
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

            services.AddTransient<ISellerProductRepository, SellerProductRepository>();
            services.AddTransient<ISellerProductApplication, SellerProductApplication>();

            services.AddTransient<ISellerProductMediaRepository, SellerProductMediaRepository>();
            services.AddTransient<ISellerProductMediaApplication, SellerProductMediaApplication>();

            services.AddTransient<ISellerPanelRepository,SellerPanelRepository>();
            services.AddTransient<ISellerPanelApplication, SellerPanelApplication>();

            services.AddDbContext<ShopContext>(item => item.UseSqlServer(connectionstring));
        }
    }
}
