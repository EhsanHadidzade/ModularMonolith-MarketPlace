using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductCategory.ProductUsageType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg.ProductUsageTypeAgg
{
    public interface IProductUsageTypeRepository : IRepository<long, ProductUsageType>
    {
        EditProductUsageType GetDetails(long id);
        List<ProductUsageTypeViewModel> GetList();
    }
}
