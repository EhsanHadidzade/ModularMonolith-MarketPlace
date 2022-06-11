using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Product
{
    public interface IProductApplication
    {
        #region AdminSide
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetList();
        #endregion

        #region ClientSide
        //To get title of a product when id is passed . using when seller want to search and add new product to his shop
        ProductViewModel GetTitleAndIdById(long id);

        //To get list of all products of admin products and show them to all clients in clientSide with special information coming from sellers
        List<MainShopProductViewModel> GetListForMainShop();

        //To Get Product Details After Selecting im Main Shop
        EditProduct GetDetailsBySlug(string slug);
        #endregion


    }
}
