using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductCategory.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg.ProductTypeAgg
{
    public interface IProductTypeRepository : IRepository<long, ProductType>
    {
        EditProductType GetDetails(long id);
        List<ProductTypeViewModel> GetList();
    }
}
