using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Domain.UserAgg;
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
        private readonly IProductRepository _productRepository;
        private readonly ISellerPanelRepository _sellerPanelRepository;
        private readonly ISellerProductRepository _sellerProductRepository;
        private readonly IUserRepository _userRepository;

        public OrderRepository(ShopContext shopContext, IProductRepository productRepository,
            ISellerProductRepository sellerProductRepository, ISellerPanelRepository sellerPanelRepository,
            IUserRepository userRepository) : base(shopContext)
        {
            _shopContext = shopContext;
            _productRepository = productRepository;
            _sellerProductRepository = sellerProductRepository;
            _sellerPanelRepository = sellerPanelRepository;
            _userRepository = userRepository;
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
                IsRevievedByUser = x.IsRecievedByUser,
                IsCanceled = x.IsCanceled,
                IssueTrackingNo = x.IssueTrackingNo,
                PaymentMethod = x.PaymentMethod,
                RefId = x.RefId,
                PaymentDate = x.PaymentDate.ToFarsi(),
                //orderItems = ProjectOrderItems(x.OrderItems)
            }).OrderByDescending(x=>x.Id).ToList();

            foreach (var order in AllOrders)
            {
                order.RecieverFullName = _userRepository.GetFullNameByUserId(order.UserId);
            }

            return AllOrders;


        }
        public Order GetCurrentOrderByUserId(long userId)
        {
            return _shopContext.Orders.Include(x => x.OrderItems).FirstOrDefault(x => x.UserId == userId && !x.IsPaid && !x.IsCanceled);
        }

        public List<OrderViewModel> GetCustomerOrdersInSellerPanelBySellerUserId(long userId)
        {

            //همه سفارشات بررسی میشوند ، اگر سفارش خاصی پیدا شد گه فقط یکی از ایتم هایش، جرء محصولات فروشنده باشد، آن سفارش قابل نمایش خواهد شد
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
                UnitPrice = x.UnitPrice,
                Count = x.Count,
            }).ToList();

            foreach (var id in sellerProductIds)
            {
                foreach (var orderItem in orderItems)
                {
                    if (orderItem.SellerProductId == id)
                    {
                        var order = _shopContext.Orders.Include(x => x.OrderItems).Select(x => new OrderViewModel
                        {
                            Id = x.Id,
                            UserId = x.UserId,
                            TotalAmount = x.TotalAmount,
                            IsPaid = x.IsPaid,
                            IsRevievedByUser = x.IsRecievedByUser,
                            IsCanceled = x.IsCanceled,
                            IssueTrackingNo = x.IssueTrackingNo,
                            PaymentMethod = x.PaymentMethod,
                            RefId = x.RefId,
                            PaymentDate = x.PaymentDate.ToFarsi(),
                            orderItems = ProjectOrderItems(x.OrderItems)
                        }).FirstOrDefault(x => x.Id == orderItem.OrderId);
                        if (!orders.Any(x => x.Id == order.Id))
                            orders.Add(order);
                    }
                }
            }
            //var AllOrders = _shopContext.Orders.Include(x => x.OrderItems).Select(x => new OrderViewModel
            //{
            //    Id = x.Id,
            //    UserId = x.UserId,
            //    TotalAmount = x.TotalAmount,
            //    IsPaid = x.IsPaid,
            //    IsRevievedByUser = x.IsRecievedByUser,
            //    IsCanceled = x.IsCanceled,
            //    IssueTrackingNo = x.IssueTrackingNo,
            //    PaymentMethod = x.PaymentMethod,
            //    RefId = x.RefId,
            //    PaymentDate = x.PaymentDate.ToFarsi(),
            //    orderItems= ProjectOrderItems(x.OrderItems)
            //}).ToList();

            //foreach (var id in sellerProductIds)
            //{
            //    foreach (var order in AllOrders)
            //    {
            //        foreach (var item in order.orderItems)
            //        {
            //            if (item.SellerProductId == id)
            //            {
            //                orders.Add(order);
            //            }
            //         }
            //    }
            //}

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
                item.SellerProductTitle = product.FarsiTitle;
                item.PictureURL = product.PictureURL;
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
            }).ToList();
        }

      
    }
}
