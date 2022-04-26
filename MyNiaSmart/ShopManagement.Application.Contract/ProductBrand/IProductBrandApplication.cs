using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductBrand
{
    public interface IProductBrandApplication
    {
        OperationResult Create(CreateProductBrand command);
        OperationResult Edit(EditProductBrand command);
        EditProductBrand GetDetails(int id);
        List<ProductBrandViewModel> GetList();
    }
}
