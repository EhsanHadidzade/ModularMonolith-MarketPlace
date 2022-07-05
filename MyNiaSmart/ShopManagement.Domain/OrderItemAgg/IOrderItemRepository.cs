using _0_Framework.Domain;
using ShopManagement.Application.Contract.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.OrderItemAgg
{
    public interface IOrderItemRepository:IRepository<long,OrderItem>
    {
        //TO Find items of one specific order . using in order view in user personal profile
        List<OrderItemViewModel> GetListByOrderId(long orderId);

        //To Get List Of Items Of Specific Order in seller panel To find items of specific order which are related to sellerProducts
        List<OrderItemViewModel> GetListWhichRelatedToSellerByOrderIdAndSellerPanelId(long orderId,long sellerPanelId);

        //To See The OrderItems of one transition in section of transitionManagement in sellerPanel 
        List<OrderItemViewModel> GetListByTransitionId(long transitionId);


    }
}
