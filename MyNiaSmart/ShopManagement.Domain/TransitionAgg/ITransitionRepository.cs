using _0_Framework.Domain;
using ShopManagement.Application.Contract.Transition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.TransitionAgg
{
    public interface ITransitionRepository:IRepository<long,Transition>
    {
        string GetTrackingNumberById(long id);

        //Using in seller panel to manage all transition
        List<TransitionViewModel> GetListBySellerPanelId(long sellerPanelId);

    }
}
