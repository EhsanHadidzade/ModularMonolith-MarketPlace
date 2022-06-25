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

        public OrderViewModel GetOrderDetailsByOrderId(long orderId)
        {
            return _orderRepository.GetOrderDetailsByOrderId(orderId);
        }
    }
}
