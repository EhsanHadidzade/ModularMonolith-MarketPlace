using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductUsageType;
using ShopManagement.Domain.ProductUsageTypeAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductUsageTypeRepository : BaseRepository<int, ProductUsageType>, IProductUsageTypeRepository
    {
        private readonly ShopContext _context;

        public ProductUsageTypeRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductUsageType GetDetails(int id)
        {
            return _context.ProductUsageTypes.Select(x => new EditProductUsageType
            {
                Id = x.Id,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductUsageTypeViewModel> GetList()
        {
            return _context.ProductUsageTypes.Select(x => new ProductUsageTypeViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }
    }
}
