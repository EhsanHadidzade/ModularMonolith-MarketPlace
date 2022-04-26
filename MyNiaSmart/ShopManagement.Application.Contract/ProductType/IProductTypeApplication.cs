using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract
{
    public interface IProductTypeApplication
    {
        OperationResult Create(CreateProductType command);
        OperationResult Edit(EditProductType command);
        EditProductType GetDetails(int id);
        List<ProductTypeViewModel> GetList();
    }
}
