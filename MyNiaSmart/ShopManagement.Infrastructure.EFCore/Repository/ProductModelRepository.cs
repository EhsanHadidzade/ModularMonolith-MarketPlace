using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Domain.ProductModelAgg;
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
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductModelViewModel> GetList()
        {
            return _context.ProductModels.Select(x => new ProductModelViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }
    }
}
