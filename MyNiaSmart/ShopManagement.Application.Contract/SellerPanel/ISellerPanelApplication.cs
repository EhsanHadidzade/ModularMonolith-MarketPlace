using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.SellerPanel
{
    public interface ISellerPanelApplication
    {

        //AdminSide
        List<SellerPanelViewModel> GetList();
        EditSellerPanel GetDetails(long id);
        OperationResult ConfirmByAdmin(long sellerPanelId);
        OperationResult CancelByAdmin(long sellerPanelId);
        OperationResult SelectAsSpecial(long sellerPanelId);

        //ClientSide
        OperationResult Create(CreateSellerPanel command);

        //ToDisable Button In UserPanel For Creation SellerPanel
        bool HasUserRequestedForSellerPanel(long userId);

        //to SHow Or Hide SellerPanel for creating their product and see Chartreports
        bool HasUserSellerPanelConfirmedByAdmin(long userId);

        //To Get sellerPanel id to use when new product is adding by seller i their panel
        long GetSellerPanelIdByUserId(long userId);


        //To Get All seller panels who are special and are selling specific product of application
        List<SellerPanelForMainShopViewModel> GetSpecialSellersWhoSellingThisProduct(string slug, int filterType);

        //To Get All seller panels who are special and are selling specific product of application
        List<SellerPanelForMainShopViewModel> GetNormalSellersWhoSellingThisProduct(string slug, int filterType);


    }
}
