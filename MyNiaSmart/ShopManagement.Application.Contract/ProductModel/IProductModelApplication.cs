using _0_Framework.Utilities;
using ShopManagement.Application.Contract.ProductModel;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductModel
{
    public interface IProductModelApplication
    {
        OperationResult Create(CreateProductModel command);
        OperationResult Edit(EditProductModel command);
        EditProductModel GetDetails(long id);
        List<ProductModelViewModel> GetList();
    }
}
