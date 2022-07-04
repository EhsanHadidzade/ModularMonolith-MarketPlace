using _0_Framework.Utilities;
using AccountManagement.Application.Contract.UserAddress;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OperationResult operation;

        public OrderApplication(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            operation = new OperationResult();
        }

        public OperationResult PayOrderUsingOnlineGateWay(GetOrderInfoToPay command)
        {
            if (command.UserAddressId == 0)
                return operation.Failed("آدرس معتبر نیست");

            var order = _orderRepository.GetById(command.Id);
            var issueTrackingNo = GenerateUniqueCode.GenerateRandomNo();

            order.PrepareToPay(command.UserAddressId, command.IsTransitionPartByPart, OrderPaymentMethod.OnlineGateWay);
            order.SetIssueTrackingNo(issueTrackingNo);
            _orderRepository.Savechange();

            #region To Do OnlinePayment Redirection

            #endregion
            order.PaymentSucceeded(233);
            _orderRepository.Savechange();

            return operation.Succedded("پرداخت انجام شد");
        }

        public List<OrderViewModel> GetCustomerOrdersInSellerPanelBySellerUserId(long userId)
        {
            return _orderRepository.GetCustomerOrdersInSellerPanelBySellerUserId(userId);
        }

        public UserAddressViewModel GetUserAddressById(long orderId)
        {
            return _orderRepository.GetUserAddressById(orderId);
        }

        public List<OrderViewModel> GetList()
        {
            return _orderRepository.GetList();
        }

        public OrderViewModel GetOrderDetailsByOrderId(long orderId)
        {
            return _orderRepository.GetOrderDetailsByOrderId(orderId);
        }

        public long GetTotalAmountById(long orderId)
        {
            return _orderRepository.GetTotalAmountById(orderId);
        }

        public List<OrderViewModel> GetUserCanceledOrdersByUserId(long userId)
        {
            return _orderRepository.GetUserCanceledOrdersByUserId(userId);
        }

        public List<OrderViewModel> GetUserCurrentOrdersByUserId(long userId)
        {
            return _orderRepository.GetUserCurrentOrdersByUserId(userId);
        }

        public List<OrderViewModel> GetUserRecievedOrdersByUserId(long userId)
        {
            return _orderRepository.GetUserRecievedOrdersByUserId(userId);
        }


    }
}
