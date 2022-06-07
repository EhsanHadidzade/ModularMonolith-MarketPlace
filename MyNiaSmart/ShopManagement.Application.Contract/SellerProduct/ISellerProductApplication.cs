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

        //AdminAndClient
        List<SellerProductViewModel> GetList();

        //to prepare model for Seller To Add New Product to their panel
        CreateSellerProduct PrepareModelForCreationBySellerPanelId(long sellerPanelId);

        //ToConfirm a product by admin in admin panel to show the product in main shop
        void ConfirmAProductByAdmin(long sellerProductId);

    }
}
