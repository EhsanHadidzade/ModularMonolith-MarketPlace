using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductModelAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductStatusAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductTypeAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductUsageTypeAgg;
using ShopManagement.Domain.SellerPanelAgg;
using ShopManagement.Domain.SellerProductAgg;
using ShopManagement.Domain.SellerProductMediaAgg;
using ShopManagement.Infrastructure.EFCore.Mapping;

namespace ShopManagement.Infrastructure.EFCore
{
    public class ShopContext:DbContext
    {
        public DbSet<ProductBrand> ProductBrands{ get; set; }
        public DbSet<ProductModel> ProductModels{ get; set; }
        public DbSet<ProductStatus> ProductStatuses{ get; set; }
        public DbSet<ProductType> ProductTypes{ get; set; }
        public DbSet<ProductUsageType> ProductUsageTypes{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<SellerPanel> SellerPanels { get; set; }
        public DbSet<SellerProduct> SellerProducts{ get; set; }
        public DbSet<SellerProductMedia> SellerProductMedias{ get; set; }

        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);

            
           
        }

    }
}
