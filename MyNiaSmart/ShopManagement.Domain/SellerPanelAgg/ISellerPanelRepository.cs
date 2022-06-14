using _0_Framework.Domain;
using ShopManagement.Application.Contract.SellerPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SellerPanelAgg
{
    public interface ISellerPanelRepository : IRepository<long, SellerPanel>
    {
        EditSellerPanel GetDetails(long id);
        List<SellerPanelViewModel> GetList();

        //ToDisable Button In UserPanel For Creation SellerPanelRequest
        bool HasUserRequestedForSellerPanel(long userId);

        //to Show Or Hide SellerPanelButton in clientSide for creating their product and see Chartreports
        bool HasUserSellerPanelConfirmedByAdmin(long userId);

        //To Get sellerPanel id to use when new product is adding by seller in their panel
        long GetSellerPanelIdByUserId(long userId);

        //To Get All seller panels who are special and are selling specific product of application
        List<SellerPanelForMainShopViewModel> GetSpecialSellersWhoSellingThisProduct(string slug, int filterType);

        //To Get All seller panels who are special and are selling specific product of application
        List<SellerPanelForMainShopViewModel> GetNormalSellersWhoSellingThisProduct(string slug, int filterType);

        //To GetSellerPanelId By SellerPanel Name . we use this when clicking on the name of sellerPanel
        //Name in product details view to find details of seller about tat specific product
        long GetIdByName(string storeName);

        

    }
}
