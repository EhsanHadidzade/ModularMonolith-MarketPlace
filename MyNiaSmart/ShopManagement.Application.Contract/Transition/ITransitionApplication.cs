using _0_Framework.Utilities;
using ShopManagement.Application.Contract.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Transition
{
    public interface ITransitionApplication
    {
        //Using in seller panel to manage all transition
        List<TransitionViewModel> GetListBySellerPanelId(long sellerPanelId);

        //To Set Specific transition as finished when client received their OrderItems
        OperationResult FinishTransitionById(long transitionId);

    }
}
