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

        public OperationResult PlaceNewOrderForUser(long userId)
        {
            if (_orderRepository.IsExist(x => x.UserId == userId && !x.IsPaid &&!x.IsCanceled))
                return operation.Failed("فاکتور باز وجود دارد");

            var order = new Order(userId);
            _orderRepository.Create(order);
            _orderRepository.Savechange();
            return operation.Succedded();
        }
    }
}
