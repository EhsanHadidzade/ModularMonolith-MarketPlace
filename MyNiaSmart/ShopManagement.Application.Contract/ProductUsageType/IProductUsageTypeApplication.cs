using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductUsageType
{
    public interface IProductUsageTypeApplication
    {
        OperationResult Create(CreateProductUsageType command);
        OperationResult Edit(EditProductUsageType command);
        EditProductUsageType GetDetails(long id);
        List<ProductUsageTypeViewModel> GetList();
    }
}
