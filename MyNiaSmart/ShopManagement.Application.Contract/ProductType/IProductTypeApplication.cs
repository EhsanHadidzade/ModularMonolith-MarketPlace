using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductType
{
    public interface IProductTypeApplication
    {
        OperationResult Create(CreateProductType command);
        OperationResult Edit(EditProductType command);
        EditProductType GetDetails(long id);
        List<ProductTypeViewModel> GetList();
    }
}
