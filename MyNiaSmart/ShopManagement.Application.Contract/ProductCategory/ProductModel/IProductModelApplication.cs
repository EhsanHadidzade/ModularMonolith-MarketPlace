using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductCategory.ProductModel
{
    public interface IProductModelApplication
    {
        OperationResult Create(CreateProductModel command);
        OperationResult Edit(EditProductModel command);
        EditProductModel GetDetails(long id);
        List<ProductModelViewModel> GetFilteredModels(long brandId);
        List<ProductModelViewModel> GetList();
    }
}
