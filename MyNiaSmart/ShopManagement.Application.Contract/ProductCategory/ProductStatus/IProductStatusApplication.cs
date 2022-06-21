using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductCategory.ProductStatus
{
    public interface IProductStatusApplication
    {
        OperationResult Create(CreateProductStatus command);
        OperationResult Edit(EditProductStatus command);
        EditProductStatus GetDetails(long id);
        List<ProductStatusViewModel> GetList();
    }
}
