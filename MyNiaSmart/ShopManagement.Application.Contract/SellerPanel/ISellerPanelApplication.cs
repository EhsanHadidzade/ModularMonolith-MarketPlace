using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.SellerPanel
{
    public interface ISellerPanelApplication
    {
        OperationResult Create(CreateSellerPanel command);
        EditSellerPanel GetDetails(long id);
        void ConfirmByAdmin(long sellerPanelId);
        void CancelByAdmin(long sellerPanelId);

        //ToDisable Button In UserPanel For Creation SellerPanel
        bool HasUserRequestedForSellerPanel(long userId);

        //to SHow Or Hide SellerPanel for creating their product and see Chartreports
        bool HasUserSellerPanelConfirmedByAdmin(long userId);

        List<SellerPanelViewModel> GetList();
    }
}
