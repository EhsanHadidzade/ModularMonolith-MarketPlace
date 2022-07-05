using _0_Framework.Contract;
using _0_Framework.Utilities;
using AccountManagement.Domain.UserAddressAgg;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.OrderItem;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.OrderItemAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.SellerPanelAgg;
using ShopManagement.Domain.SellerProductAgg;
using ShopManagement.Domain.TransitionAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class OrderItemApplication : IOrderItemApplication
    {
        private OperationResult operation;
        private readonly IAuthHelper _authHelper;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ITransitionRepository _transitionRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly ISellerPanelRepository _sellerPanelRepository;
        private readonly ISellerProductRepository _sellerProductRepository;

        public OrderItemApplication(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository,
            IAuthHelper authHelper, IProductRepository productRepository, ISellerProductRepository sellerProductRepository,
            ITransitionRepository transitionRepository, ISellerPanelRepository sellerPanelRepository, IUserAddressRepository userAddressRepository)
        {
            operation = new OperationResult();
            _authHelper = authHelper;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _sellerProductRepository = sellerProductRepository;
            _transitionRepository = transitionRepository;
            _sellerPanelRepository = sellerPanelRepository;
            _userAddressRepository = userAddressRepository;
        }

        public OperationResult AddOrderItem(CreateOrderItem command)
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var currentOrder = _orderRepository.GetCurrentOrderByUserId(userId);
            var orderItem = new OrderItem();

            if (currentOrder != null)
            {
                if (_orderItemRepository.IsExist(x => x.SellerProductId == command.SellerProductId && x.OrderId == currentOrder.Id))
                    return operation.Failed("محصول در سبد خرید شما موجود میباشد. امکان افزودن دوباره وجود ندارد");

                orderItem = new OrderItem(command.SellerProductId, command.Count, command.UnitPrice, currentOrder.Id);
                currentOrder.AddItem(orderItem);
                currentOrder.IncreaseTotalAmount(orderItem.UnitPrice);
                _orderRepository.Savechange();
                return operation.Succedded("محصول به سبد شما اضافه شد، برای مدیریت بهتر روی آن کلیک کنید");
            }

            currentOrder = new Order(userId);
            _orderRepository.Create(currentOrder);
            _orderRepository.Savechange();

            orderItem = new OrderItem(command.SellerProductId, command.Count, command.UnitPrice, currentOrder.Id);
            currentOrder.AddItem(orderItem);
            currentOrder.IncreaseTotalAmount(orderItem.UnitPrice);
            _orderRepository.Savechange();
            operation.Id = currentOrder.Id;
            return operation.Succedded("محصول به سبد شما اضافه شد، برای مدیریت بهتر روی آن کلیک کنید");

        }

        public OperationResult SendOrderItemsByAdminWithIds(List<long> ToSendOrderItems)
        {
            throw new NotImplementedException();
        }

        public OperationResult SendOrderItemsBySellerWithIds(List<long> ToSendOrderItems)
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var orderId = new long();
            var sellerPanelId = _sellerPanelRepository.GetSellerPanelIdByUserId(userId);

            var trackingNo = GenerateUniqueCode.GenerateRandomNo();
            var deliveryDuration = GetDeliveryDurationForItemsBuyerByOrderItemIds(ToSendOrderItems);

            if (deliveryDuration == 0)
                return operation.Failed("آدرسی برای دریافت کننده محصول یافت نشد");


            var transition = new Transition(sellerPanelId, trackingNo, deliveryDuration);
            _transitionRepository.Create(transition);
            _transitionRepository.Savechange();

            foreach (var id in ToSendOrderItems)
            {
                var orderItem = _orderItemRepository.GetById(id);

                if (orderItem.TransitionId != 0)
                {
                    _transitionRepository.RemoveById(transition.Id);
                    _transitionRepository.Savechange();
                    return operation.Failed("این ریز فاکتور ارسال شده و دارای کد ارسال میباشد");
                }
                orderItem.TransitedBy(transition.Id);
                _orderItemRepository.Savechange();

                if (orderId == 0)
                    orderId = orderItem.OrderId;
            }

            var order = _orderRepository.GetWithOrderItemsById(orderId);
            if (!order.OrderItems.Any(x => x.TransitionId == 0))
            {
                order.SetAsDelivered();
                _orderRepository.Savechange();
            }

            #region To DO Sending SMS to buyer and tell them the TransitionTrackingNumber

            #endregion

            return operation.Succedded($"ارسال با موفقیت ثبت و به مشتری از طریق اس ام اس گزارش داده شده است. کد رهگیری ارسال :{transition.TrackingNumber}");
        }

        //لیست ایتم های ورودی، مختص یک فروشنده و یک اردر میباشند
        public int GetDeliveryDurationForItemsBuyerByOrderItemIds(List<long> orderItemIds)
        {
            //لیست محصولات فروشنده که در ریز فاکتور موجود میباشد
            var list = new List<SellerProduct>();
            foreach (var id in orderItemIds)
            {
                var item = _orderItemRepository.GetById(id);
                var sellerProduct = _sellerProductRepository.GetById(item.SellerProductId);
                list.Add(sellerProduct);
            }

            var orderItem = _orderItemRepository.GetById(orderItemIds.First());

            //فروشنده خاص
            var sellerPanel = _sellerPanelRepository.GetBySellerProductId(orderItem.SellerProductId);

            var order = _orderRepository.GetById(orderItem.OrderId);
            var userAddress = _userAddressRepository.GetById(order.UserAddressId);

            if (userAddress == null)
                return 0;

            if (sellerPanel.City == userAddress.City && sellerPanel.Capital == userAddress.Capital)
                return list.Select(x => x.DeliveryDurationForCity).Max();

            if (sellerPanel.City != userAddress.City && sellerPanel.Capital == userAddress.Capital)
                return list.Select(x => x.DeliveryDurationForCapital).Max();

            return list.Select(x => x.DeliveryDurationForOther).Max();

        }

        public List<OrderItemViewModel> GetCurrdentOrderItemsByUserId(long userId)
        {
            var currentOrder = _orderRepository.GetCurrentOrderByUserId(userId);
            if (currentOrder == null)
                return new List<OrderItemViewModel>();

            var orderItems = currentOrder.OrderItems;
            return ProjectOrderItems(orderItems);
        }

        private List<OrderItemViewModel> ProjectOrderItems(List<OrderItem> orderItems)
        {
            var projectedOrderItems = orderItems.Select(x => new OrderItemViewModel()
            {
                Id = x.Id,
                SellerProductId = x.SellerProductId,
                UnitPrice = x.UnitPrice,
                Count = x.Count,
                OrderId = x.OrderId,
            }).ToList();

            foreach (var item in projectedOrderItems)
            {
                var productId = _sellerProductRepository.GetProductIdBySellerProductId(item.SellerProductId);
                var product = _productRepository.GetInfoById(productId);
                item.SellerProductTitle = product.FarsiTitle;
                item.PictureURL = product.PictureURL;
            }

            return projectedOrderItems;
        }

        public long UpdateByIdAndCount(long orderItemId, int count)
        {
            var orderItem = _orderItemRepository.GetById(orderItemId);
            if (count == 0)
            {
                _orderItemRepository.RemoveById(orderItemId);
                _orderItemRepository.Savechange();
            }
            else
            {
                //To Find Exact Price Of Seller
                var productPrice = _sellerProductRepository.GetSellerPriceBySellerproductId(orderItem.SellerProductId);

                orderItem.Update(count, count * productPrice);
                _orderItemRepository.Savechange();
            }

            var specificOrder = _orderRepository.GetOrderDetailsByOrderId(orderItem.OrderId);
            var orderTotalAmount = specificOrder.orderItems.Select(x => x.UnitPrice).ToList().Sum();

            var order = _orderRepository.GetById(orderItem.OrderId);
            order.UpdateTotalAmount(orderTotalAmount);
            _orderRepository.Savechange();

            return order.Id;



        }

        public List<OrderItemViewModel> GetListByOrderId(long orderId)
        {
            return _orderItemRepository.GetListByOrderId(orderId);
        }

        public List<OrderItemViewModel> GetListWhichRelatedToSellerByOrderIdAndSellerPanelId(long orderId, long sellerPanelId)
        {
            return _orderItemRepository.GetListWhichRelatedToSellerByOrderIdAndSellerPanelId(orderId, sellerPanelId);
        }

        public List<OrderItemViewModel> GetListByTransitionId(long transitionId)
        {
            return _orderItemRepository.GetListByTransitionId(transitionId);
        }
    }
}
