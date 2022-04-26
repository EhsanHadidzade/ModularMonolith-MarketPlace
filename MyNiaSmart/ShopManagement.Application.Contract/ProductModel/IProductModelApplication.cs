using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductBrand
{
    public interface IProductModelApplication
    {
        OperationResult Create(CreateProductModel command);
        OperationResult Edit(EditProductModel command);
        EditProductModel GetDetails(int id);
        List<ProductModelViewModel> GetList();
    }
}
