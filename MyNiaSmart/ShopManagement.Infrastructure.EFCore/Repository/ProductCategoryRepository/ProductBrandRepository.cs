using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductCategory.ProductBrand;
using ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository.ProductCategoryRepository
{
    public class ProductBrandRepository : BaseRepository<long, ProductBrand>, IProductBrandRepository
    {
        private readonly ShopContext _context;

        public ProductBrandRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductBrand GetDetails(long id)
        {
            return _context.ProductBrands.Select(x => new EditProductBrand
            {
                Id = x.Id,
                EngTitle = x.EngTitle,
                FarsiTitle = x.FarsiTitle,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductBrandViewModel> GetList()
        {
            return _context.ProductBrands.Select(x => new ProductBrandViewModel
            {
                Id = x.Id,
                FarsiTitle = x.FarsiTitle,
                EngTitle = x.EngTitle
            }).ToList();
        }
    }
}
