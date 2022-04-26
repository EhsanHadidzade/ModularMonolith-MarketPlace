using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductStatus;
using ShopManagement.Domain.ProductStatusAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductStatusRepository : BaseRepository<int, ProductStatus>, IProductStatusRepository
    {
        private readonly ShopContext _context;

        public ProductStatusRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductStatus GetDetails(int id)
        {
            return _context.ProductStatuses.Select(x => new EditProductStatus
            {
                Id = x.Id,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductStatusViewModel> GetList()
        {
            return _context.ProductStatuses.Select(x => new ProductStatusViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }
    }
}
