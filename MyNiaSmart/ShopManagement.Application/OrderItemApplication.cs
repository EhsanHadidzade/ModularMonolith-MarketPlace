﻿using _0_Framework.Contract;
using _0_Framework.Utilities;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.OrderItem;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.OrderItemAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.SellerProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class OrderItemApplication : IOrderItemApplication
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderApplication _orderApplication;
        private readonly IAuthHelper _authHelper;
        private OperationResult operation;
        private readonly ISellerProductRepository _sellerProductRepository;

        public OrderItemApplication(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository,
            IAuthHelper authHelper, IOrderApplication orderApplication, IProductRepository productRepository,
            ISellerProductRepository sellerProductRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _authHelper = authHelper;
            _orderApplication = orderApplication;
            operation = new OperationResult();
            _productRepository = productRepository;
            _sellerProductRepository = sellerProductRepository;
        }

        public OperationResult AddOrderItem(CreateOrderItem command)
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var currentOrder = _orderRepository.GetCurrentOrderByUserId(userId);
            var orderItem = new OrderItem();

            if (currentOrder != null)
            {
                if (_orderItemRepository.IsExist(x => x.SellerProductId == command.SellerProductId && x.OrderId == currentOrder.Id))
                {
                    return operation.Failed("محصول در سبد خرید شما موجود میباشد. امکان افزودن دوباره وجود ندارد");

                }

                orderItem = new OrderItem(command.SellerProductId, command.Count, command.UnitPrice, currentOrder.Id);
                currentOrder.AddItem(orderItem);
                _orderRepository.Savechange();
                return operation.Succedded("محصول به سبد شما اضافه شد، برای مدیریت بهتر روی آن کلیک کنید");
            }

            currentOrder = new Order(userId);
            _orderRepository.Create(currentOrder);
            _orderRepository.Savechange();

            orderItem = new OrderItem(command.SellerProductId, command.Count, command.UnitPrice, currentOrder.Id);
            currentOrder.AddItem(orderItem);
            _orderRepository.Savechange();
            return operation.Succedded("محصول به سبد شما اضافه شد، برای مدیریت بهتر روی آن کلیک کنید");

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
                SellerProductId = x.SellerProductId,
                UnitPrice = x.UnitPrice,
                Count = x.Count,
                OrderId = x.OrderId,
            }).ToList();
            foreach (var item in projectedOrderItems)
            {
                var productId = _sellerProductRepository.GetProductIdBySellerProductId(item.SellerProductId);
                var product=_productRepository.GetInfoById(productId);
                item.SellerProductTitle = product.FarsiTitle;
                item.PictureURL = product.PictureURL;
            }

            return projectedOrderItems;
        }
    }
}
