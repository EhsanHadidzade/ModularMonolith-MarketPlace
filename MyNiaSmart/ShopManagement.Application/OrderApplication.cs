using _0_Framework.Utilities;
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

        public List<OrderViewModel> GetCustomerOrdersInSellerPanelBySellerUserId(long userId)
        {
            return _orderRepository.GetCustomerOrdersInSellerPanelBySellerUserId(userId);
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
