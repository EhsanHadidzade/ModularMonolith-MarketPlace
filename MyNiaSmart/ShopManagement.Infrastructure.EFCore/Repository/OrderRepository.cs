using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.UserAddress;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.OrderItem;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.OrderItemAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.SellerPanelAgg;
using ShopManagement.Domain.SellerProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository : BaseRepository<long, Order>, IOrderRepository
    {
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;
        private readonly IProductRepository _productRepository;
        private readonly ISellerPanelRepository _sellerPanelRepository;
        private readonly ISellerProductRepository _sellerProductRepository;
        private readonly IUserRepository _userRepository;

        public OrderRepository(ShopContext shopContext, IProductRepository productRepository,
            ISellerProductRepository sellerProductRepository, ISellerPanelRepository sellerPanelRepository,
            IUserRepository userRepository, AccountContext accountContext) : base(shopContext)
        {
            _shopContext = shopContext;
            _productRepository = productRepository;
            _sellerProductRepository = sellerProductRepository;
            _sellerPanelRepository = sellerPanelRepository;
            _userRepository = userRepository;
            _accountContext = accountContext;
        }
        public bool DoesUserHaveOpenOrder(long userId)
        {
            return _shopContext.Orders.Any(x => x.UserId == userId && !x.IsPaid && !x.IsCanceled);
        }
        public List<OrderViewModel> GetList()
        {
            var AllOrders = _shopContext.Orders.Include(x => x.OrderItems).Select(x => new OrderViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                TotalAmount = x.TotalAmount,
                IsPaid = x.IsPaid,
                IsCanceled = x.IsCanceled,
                IsDelivered=x.IsDelivered,
                IsRevievedByUser = x.IsRecievedByUser,
                PaymentDate = x.PaymentDate.ToFarsi(),
                ReceiptDate = x.ReceiptDate.ToFarsi(),
                DeliveryDate=x.DeliveryDate.ToFarsi(),
                CancelDate=x.CancelDate.ToFarsi(),
                IsTransitionPartByPart = x.IsTransitionPartByPart,
                IssueTrackingNo = x.IssueTrackingNo,
                PaymentMethod = x.PaymentMethod,
                RefId = x.RefId,
                //orderItems = ProjectOrderItems(x.OrderItems)
            }).OrderByDescending(x => x.Id).ToList();

            foreach (var order in AllOrders)
            {
                order.RecieverFullName = _userRepository.GetFullNameByUserId(order.UserId);
            }

            return AllOrders;
        }

        public UserAddressViewModel GetUserAddressById(long orderId)
        {
            var order = _shopContext.Orders.Select(x => new { x.Id, x.UserAddressId }).FirstOrDefault(x => x.Id == orderId);
            return _accountContext.UserAddresses.Select(x => new UserAddressViewModel
            {
                Id = x.Id,
                Address = x.Address,
                PostalCode = x.PostalCode,
                Capital = x.Capital,
                City = x.City,
                MobileNumber = x.MobileNumber
            }).FirstOrDefault(x => x.Id == order.UserAddressId);
        }

        public Order GetCurrentOrderByUserId(long userId)
        {
            return _shopContext.Orders.Include(x => x.OrderItems).FirstOrDefault(x => x.UserId == userId && !x.IsPaid && !x.IsCanceled);
        }

        public List<OrderViewModel> GetCustomerOrdersInSellerPanelBySellerUserId(long userId)
        {

            //همه سفارشات بررسی میشوند ، اگر سفارش خاصی پیدا شد که فقط یکی از ایتم هایش، جرء محصولات فروشنده باشد، آن سفارش قابل نمایش خواهد شد
            var orders = new List<OrderViewModel>();

            var sellerPanelId = _sellerPanelRepository.GetSellerPanelIdByUserId(userId);
            if (sellerPanelId == 0)
                return orders;

            var sellerProductIds = _sellerProductRepository.GetIdsBySellerPanelId(sellerPanelId);

            var orderItems = _shopContext.OrderItems.Select(x => new OrderItemViewModel()
            {
                Id = x.Id,
                OrderId = x.OrderId,
                SellerProductId = x.SellerProductId,
                TransitionId = x.TransitionId,
            }).ToList();

            foreach (var id in sellerProductIds)
            {
                //استخراج order های خاص مربوط به فروشده
                foreach (var orderItem in orderItems)
                {
                    if (orderItem.SellerProductId == id)
                    {
                        var order = _shopContext.Orders.Include(x => x.OrderItems).Select(x => new OrderViewModel
                        {
                            Id = x.Id,
                            UserId = x.UserId,
                            TotalAmount = x.TotalAmount,
                            IsTransitionPartByPart = x.IsTransitionPartByPart,
                            IsPaid = x.IsPaid,
                            IsRevievedByUser = x.IsRecievedByUser,
                            IsCanceled = x.IsCanceled,
                            IssueTrackingNo = x.IssueTrackingNo,
                            PaymentMethod = x.PaymentMethod,
                            RefId = x.RefId,
                            PaymentDate = x.PaymentDate.ToFarsi(),
                            orderItems = new List<OrderItemViewModel>(),
                        }).FirstOrDefault(x => x.Id == orderItem.OrderId);

                        if (!orders.Any(x => x.Id == order.Id))
                            orders.Add(order);
                    }
                }
            }

            //استخراج ایتم های هر اردر مختص فروشنده 
            foreach (var order in orders)
            {
                var list = new List<OrderItemViewModel>();

                foreach (var id in sellerProductIds)
                {
                    var orderItem = _shopContext.OrderItems.Select(x => new OrderItemViewModel
                    {
                        Id = x.Id,
                        OrderId = x.OrderId,
                        SellerProductId = x.SellerProductId,
                        TransitionId = x.TransitionId
                    }).FirstOrDefault(x => x.OrderId == order.Id && x.SellerProductId == id);

                    if(orderItem != null)
                    list.Add(orderItem);
                }
                order.orderItems = list;
            }


            foreach (var item in orders)
            {
                item.RecieverFullName = _userRepository.GetFullNameByUserId(item.UserId);
            }

            return orders;

        }

        public OrderViewModel GetOrderDetailsByOrderId(long orderId)
        {
            var order = _shopContext.Orders.Include(x => x.OrderItems).Select(x => new OrderViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                TotalAmount = x.TotalAmount,
                IsPaid = x.IsPaid,
                IsCanceled = x.IsCanceled,
                orderItems = ProjectOrderItems(x.OrderItems)
            }).FirstOrDefault(x => x.Id == orderId);

            if (order.orderItems.Count == 0)
            {
                return order;
            }

            foreach (var item in order.orderItems)
            {
                var productId = _sellerProductRepository.GetProductIdBySellerProductId(item.SellerProductId);

                var product = _productRepository.GetInfoById(productId);
                var sellerPanel = _sellerPanelRepository.GetBySellerProductId(item.SellerProductId);
                var sellerProduct = _sellerProductRepository.GetById(item.SellerProductId);

                item.SellerProductTitle = product.FarsiTitle;
                item.PictureURL = product.PictureURL;

                item.SellerShopName = _sellerPanelRepository.GetShopNameBySellerProductId(item.SellerProductId);
                item.SellerCity = sellerPanel.City;
                item.SellerCapital = sellerPanel.Capital;

                item.SellerDeliveryDurationForCity = sellerProduct.DeliveryDurationForCity;
                item.SellerDeliveryDurationForCapital = sellerProduct.DeliveryDurationForCapital;
                item.SellerDeliveryDurationForOther = sellerProduct.DeliveryDurationForOther;
            }

            return order;
        }

        public long GetTotalAmountById(long orderId)
        {
            var order = _shopContext.Orders.Select(x => new { x.Id, x.TotalAmount }).FirstOrDefault(x => x.Id == orderId);
            return order.TotalAmount;
        }

        public List<OrderViewModel> GetUserCanceledOrdersByUserId(long userId)
        {
            var currentOrders = _shopContext.Orders.Include(x => x.OrderItems).Select(x => new OrderViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                TotalAmount = x.TotalAmount,
                IsPaid = x.IsPaid,
                IsRevievedByUser = x.IsRecievedByUser,
                IsCanceled = x.IsCanceled,
                orderItems = ProjectOrderItems(x.OrderItems)
            }).Where(x => x.UserId == userId && !x.IsPaid && x.IsCanceled && !x.IsRevievedByUser).OrderByDescending(x => x.Id).ToList();
            foreach (var order in currentOrders)
            {
                foreach (var item in order.orderItems)
                {
                    var productId = _sellerProductRepository.GetProductIdBySellerProductId(item.SellerProductId);
                    var product = _productRepository.GetInfoById(productId);
                    item.SellerProductTitle = product.FarsiTitle;
                    item.PictureURL = product.PictureURL;
                }

            }
            return currentOrders;
        }

        public List<OrderViewModel> GetUserCurrentOrdersByUserId(long userId)
        {
            var currentOrders = _shopContext.Orders.Include(x => x.OrderItems).Select(x => new OrderViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                TotalAmount = x.TotalAmount,
                IsPaid = x.IsPaid,
                IsRevievedByUser = x.IsRecievedByUser,
                PaymentDate = x.PaymentDate.ToFarsi(),
                IsCanceled = x.IsCanceled,
                IssueTrackingNo = x.IssueTrackingNo,
                orderItems = ProjectOrderItems(x.OrderItems)
            }).Where(x => x.UserId == userId && x.IsPaid && !x.IsCanceled && !x.IsRevievedByUser).OrderByDescending(x => x.Id).ToList();
            foreach (var order in currentOrders)
            {
                foreach (var item in order.orderItems)
                {
                    var productId = _sellerProductRepository.GetProductIdBySellerProductId(item.SellerProductId);
                    var product = _productRepository.GetInfoById(productId);
                    item.SellerProductTitle = product.FarsiTitle;
                    item.PictureURL = product.PictureURL;
                }
            }
            return currentOrders;
        }

        public List<OrderViewModel> GetUserRecievedOrdersByUserId(long userId)
        {
            var currentOrders = _shopContext.Orders.Include(x => x.OrderItems).Select(x => new OrderViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                TotalAmount = x.TotalAmount,
                IssueTrackingNo = x.IssueTrackingNo,
                IsPaid = x.IsPaid,
                PaymentDate = x.PaymentDate.ToFarsi(),
                ReceiptDate = x.ReceiptDate.ToFarsi(),
                IsRevievedByUser = x.IsRecievedByUser,
                IsCanceled = x.IsCanceled,
                orderItems = ProjectOrderItems(x.OrderItems)
            }).Where(x => x.UserId == userId && x.IsPaid && !x.IsCanceled && x.IsRevievedByUser).OrderByDescending(x => x.Id).ToList();

            foreach (var order in currentOrders)
            {
                foreach (var item in order.orderItems)
                {
                    var productId = _sellerProductRepository.GetProductIdBySellerProductId(item.SellerProductId);
                    var product = _productRepository.GetInfoById(productId);
                    item.SellerProductTitle = product.FarsiTitle;
                    item.PictureURL = product.PictureURL;
                }
            }
            return currentOrders;
        }

        private static List<OrderItemViewModel> ProjectOrderItems(List<OrderItem> orderItems)
        {
            return orderItems.Select(x => new OrderItemViewModel()
            {
                Id = x.Id,
                OrderId = x.OrderId,
                SellerProductId = x.SellerProductId,
                UnitPrice = x.UnitPrice,
                Count = x.Count,
                TransitionId = x.TransitionId,
            }).ToList();
        }

        public Order GetWithOrderItemsById(long id)
        {
            return _shopContext.Orders.Include(x => x.OrderItems).FirstOrDefault(x => x.Id == id);
        }
    }
}
