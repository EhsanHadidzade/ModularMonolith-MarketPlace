using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.SellerProduct
{
    public interface ISellerProductApplication
    {
       

        //ClientSide
        OperationResult Create(CreateSellerProduct command);
        OperationResult Edit(EditSellerProduct command);
        EditSellerProduct GetDetails(long id);

        //AdminPanel to manage new product that sellers are going to cooperate for selling them
        List<SellerProductViewModel> GetList();


        //to get list of products to show in seller panel of sellers
        List<SellerProductViewModel> GetListBySellerPanelId(long sellerpanelId);


        //to prepare model for Seller To Add New Product to their panel
        CreateSellerProduct PrepareModelForCreationBySellerPanelId(long sellerPanelId);

        //ToConfirm a product by admin in admin panel to show the product in main shop
        OperationResult ConfirmAProductByAdmin(long sellerProductId);

    }
}
