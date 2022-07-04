using _0_Framework.Utilities;
using ShopManagement.Application.Contract.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.OrderItem
{
    public interface IOrderItemApplication
    {
        //To Use when client want to buy a product and click on button(افزودن به سبد خرید)
        OperationResult AddOrderItem(CreateOrderItem command);

        List<OrderItemViewModel> GetCurrdentOrderItemsByUserId(long userId);

        //To Update SpecificOrderItem And Also Related Order then we return orderId
        long UpdateByIdAndCount(long orderItemId, int count);

        //TO Find items of one specific order . using in order view in user personal profile
        List<OrderItemViewModel> GetListByOrderId(long orderId);

        //To Get List Of Items Of Specific Order in seller panel To find items of specific order which are related to sellerProducts
        List<OrderItemViewModel> GetListWhichRelatedToSellerByOrderIdAndSellerPanelId(long orderId, long sellerPanelId);

        //To Send OrderItems By Seller And Creating transition 
        OperationResult SendOrderItemsBySellerWithIds(List<long> ToSendOrderItems);

        //To Send OrderItems By Administrator And Creating new transition
        OperationResult SendOrderItemsByAdminWithIds(List<long> ToSendOrderItems);

        //To Find How much Time is need to send Some OrderItems With a transition by seller . using while creating new transiton in sellerPanel to send items
        int GetDeliveryDurationForItemsBuyerByOrderItemIds(List<long> orderItemIds);



    }
}
