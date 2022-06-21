using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductCategory.ProductBrand;
using ShopManagement.Application.Contract.ProductCategory.ProductModel;
using ShopManagement.Domain.ProductCategoryAgg.ProductModelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductModelRepository : BaseRepository<long, ProductModel>, IProductModelRepository
    {
        private readonly ShopContext _context;

        public ProductModelRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductModel GetDetails(long id)
        {
            return _context.ProductModels.Select(x => new EditProductModel
            {
                Id = x.Id,
                EngTitle = x.EngTitle,
                FarsiTitle = x.FarsiTitle,
                ProductBrandId = x.ProductBrandId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductModelViewModel> GetFilteredModels(long brandId)
        {
            var query = _context.ProductModels.Include(x => x.ProductBrand)
                .Select(x => new ProductModelViewModel
                {
                    Id = x.Id,
                    EngTitle = x.EngTitle,
                    FarsiTitle=x.FarsiTitle,
                    ProductBrandId = x.ProductBrandId,
                    ProductBrandTitle = x.ProductBrand.EngTitle
                });

            if (brandId > 0)
            {
                query = query.Where(x => x.ProductBrandId == brandId);
            }
            return query.ToList();

        }

        public List<ProductModelViewModel> GetList()
        {
            return _context.ProductModels.Include(x => x.ProductBrand)
                .Select(x => new ProductModelViewModel
                {
                    Id = x.Id,
                    EngTitle = x.EngTitle,
                    FarsiTitle=x.FarsiTitle,
                    ProductBrandId = x.ProductBrandId,
                    ProductBrandTitle = x.ProductBrand.EngTitle
                }).ToList();
        }
    }
}
