using _0_Framework.Utilities;
using ShopManagement.Application.Contract.Transition;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.OrderItemAgg;
using ShopManagement.Domain.TransitionAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class TransitionApplication : ITransitionApplication
    {
        private readonly ITransitionRepository _transitionRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;

        public TransitionApplication(ITransitionRepository transitionRepository, IOrderItemRepository orderItemRepository,
            IOrderRepository orderRepository)
        {
            _transitionRepository = transitionRepository;
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
        }

        public OperationResult FinishTransitionById(long transitionId)
        {
            var operation = new OperationResult();

            var transition = _transitionRepository.GetById(transitionId);
            if(transition == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (transition.IsFinished)
                return operation.Failed("قبلا به عنوان مرسوله نهایی ، ثبت شده است");

            transition.SetAsDone();
            _transitionRepository.Savechange();

            #region TO Check if related order is Completelly Received By User Or Not

            var orderItem=_orderItemRepository.GetListByTransitionId(transitionId).First();
            var orderId = orderItem.OrderId;
            var order=_orderRepository.GetWithOrderItemsById(orderId);

            if (!order.OrderItems.Any(x => x.TransitionId == 0))
            {
                order.SetAsRecieved();
                _orderRepository.Savechange();
            }

            #endregion
            return operation.Succedded("مرسوله با موفقیت  نهایی شد");
        }

        public List<TransitionViewModel> GetListBySellerPanelId(long sellerPanelId)
        {
            return _transitionRepository.GetListBySellerPanelId(sellerPanelId);
        }
    }
}
