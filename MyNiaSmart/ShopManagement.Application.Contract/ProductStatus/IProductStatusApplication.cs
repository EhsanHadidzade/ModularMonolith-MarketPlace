using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductStatus
{
    public interface IProductStatusApplication
    {
        OperationResult Create(CreateProductStatus command);
        OperationResult Edit(EditProductStatus command);
        EditProductStatus GetDetails(int id);
        List<ProductStatusViewModel> GetList();
    }
}
