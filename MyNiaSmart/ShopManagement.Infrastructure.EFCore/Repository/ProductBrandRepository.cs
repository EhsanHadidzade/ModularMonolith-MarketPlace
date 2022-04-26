using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Domain.ProductBrandAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductBrandRepository : BaseRepository<int, ProductBrand>, IProductBrandRepository
    {
        private readonly ShopContext _context;

        public ProductBrandRepository(ShopContext context):base(context)
        {
            _context = context;
        }

        public EditProductBrand GetDetails(int id)
        {
            return _context.ProductBrands.Select(x=>new EditProductBrand
            {
                Id=x.Id,
                Title=x.Title
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<ProductBrandViewModel> GetList()
        {
            return _context.ProductBrands.Select(x => new ProductBrandViewModel
            {
                Id = x.Id,
                Title=x.Title
            }).ToList();
        }
    }
}
