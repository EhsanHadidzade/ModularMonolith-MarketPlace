using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.SellerPanel
{
    public interface ISellerPanelApplication
    {
        OperationResult Create(CreateSellerPanel command,List<long> userPersonalityRequestsIds);
        List<SellerPanelViewModel> GetList();
    }
}
