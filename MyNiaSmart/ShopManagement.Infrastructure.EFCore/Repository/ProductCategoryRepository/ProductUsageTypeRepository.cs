using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductCategory.ProductUsageType;
using ShopManagement.Domain.ProductCategoryAgg.ProductUsageTypeAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductUsageTypeRepository : BaseRepository<long, ProductUsageType>, IProductUsageTypeRepository
    {
        private readonly ShopContext _context;

        public ProductUsageTypeRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductUsageType GetDetails(long id)
        {
            return _context.ProductUsageTypes.Select(x => new EditProductUsageType
            {
                Id = x.Id,
                EngTitle = x.EngTitle,
                FarsiTitle = x.FarsiTitle,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductUsageTypeViewModel> GetList()
        {
            return _context.ProductUsageTypes.Select(x => new ProductUsageTypeViewModel
            {
                Id = x.Id,
                EngTitle = x.EngTitle,
                FarsiTitle=x.FarsiTitle
            }).ToList();
        }
    }
}
