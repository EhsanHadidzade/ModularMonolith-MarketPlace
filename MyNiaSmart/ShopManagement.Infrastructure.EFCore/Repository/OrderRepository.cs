using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using Microsoft.EntityFrameworkCore;
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

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository : BaseRepository<long, Order>, IOrderRepository
    {
        private readonly ShopContext _shopContext;
        private readonly IProductRepository _productRepository;
        private readonly ISellerProductRepository _sellerProductRepository;

        public OrderRepository(ShopContext shopContext, IProductRepository productRepository,
            ISellerProductRepository sellerProductRepository) : base(shopContext)
        {
            _shopContext = shopContext;
            _productRepository = productRepository;
            _sellerProductRepository = sellerProductRepository;
        }

        public bool DoesUserHaveOpenOrder(long userId)
        {
            return _shopContext.Orders.Any(x => x.UserId == userId && !x.IsPaid && !x.IsCanceled);
        }

        public Order GetCurrentOrderByUserId(long userId)
        {
            return _shopContext.Orders.Include(x => x.OrderItems).FirstOrDefault(x => x.UserId == userId && !x.IsPaid && !x.IsCanceled);
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

            //order.orderItems = _shopContext.OrderItems.Select(x => new OrderItemViewModel()
            //{
            //    Id = x.Id,
            //    OrderId = x.OrderId,
            //    SellerProductId = x.SellerProductId,
            //    UnitPrice = x.UnitPrice,
            //    Count = x.Count,
            //}).Where(x => x.OrderId == order.Id).ToList();

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
            }).Where(x => x.UserId == userId && !x.IsPaid && x.IsCanceled && !x.IsRevievedByUser).ToList();
            foreach (var order in currentOrders)
            {
                //order.orderItems = _shopContext.OrderItems.Select(x => new OrderItemViewModel()
                //{
                //    Id = x.Id,
                //    OrderId = x.OrderId,
                //    SellerProductId = x.SellerProductId,
                //    UnitPrice = x.UnitPrice,
                //    Count = x.Count,
                //}).Where(x => x.OrderId == order.Id).ToList();

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
                PaymentDate=x.PaymentDate.ToFarsi(),
                IsCanceled = x.IsCanceled,
                IssueTrackingNo = x.IssueTrackingNo,
                orderItems = ProjectOrderItems(x.OrderItems)
            }).Where(x => x.UserId == userId && x.IsPaid && !x.IsCanceled && !x.IsRevievedByUser).ToList();
            foreach (var order in currentOrders)
            {
                //order.orderItems = _shopContext.OrderItems.Select(x => new OrderItemViewModel()
                //{
                //    Id = x.Id,
                //    OrderId = x.OrderId,
                //    SellerProductId = x.SellerProductId,
                //    UnitPrice = x.UnitPrice,
                //    Count = x.Count,
                //}).Where(x => x.OrderId == order.Id).ToList();

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
                IsPaid = x.IsPaid,
                IsRevievedByUser = x.IsRecievedByUser,
                IsCanceled = x.IsCanceled,
                orderItems = ProjectOrderItems(x.OrderItems)
            }).Where(x => x.UserId == userId && x.IsPaid && !x.IsCanceled && x.IsRevievedByUser).ToList();

            foreach (var order in currentOrders)
            {
                //order.orderItems = _shopContext.OrderItems.Select(x => new OrderItemViewModel()
                //{
                //    Id = x.Id,
                //    OrderId = x.OrderId,
                //    SellerProductId = x.SellerProductId,
                //    UnitPrice = x.UnitPrice,
                //    Count = x.Count,
                //}).Where(x => x.OrderId == order.Id).ToList();

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
