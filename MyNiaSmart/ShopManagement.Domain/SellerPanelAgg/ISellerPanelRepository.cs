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

        //ToDisable Button In UserPanel For Creation SellerPanel
        bool HasUserRequestedForSellerPanel(long userId);

        //to SHow Or Hide SellerPanel for creating their product and see Chartreports
        bool HasUserSellerPanelConfirmedByAdmin(long userId);

    }
}
