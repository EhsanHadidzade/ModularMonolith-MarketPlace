using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetList();

        //To get title of a product whem slug is passed . using when seller want to search and add new product to his shop
        ProductViewModel GetTitleAndIdById(long id);
    }
}
