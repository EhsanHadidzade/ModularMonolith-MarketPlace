using _0_Framework.Infrastructure;
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
    public class OrderRepository:BaseRepository<long,Order>, IOrderRepository
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
            return _shopContext.Orders.Any(x => x.UserId == userId && !x.IsPaid &&!x.IsCanceled);
        }

        public Order GetCurrentOrderByUserId(long userId)
        {
            return _shopContext.Orders.Include(x=>x.OrderItems).FirstOrDefault(x=>x.UserId == userId &&!x.IsPaid && !x.IsCanceled);
        }

        public OrderViewModel GetOrderDetails(long userId)
        {
            return _shopContext.Orders.Include(x => x.OrderItems).Select(x=>new OrderViewModel
            {
                UserId=x.UserId,
                TotalAmount=x.TotalAmount,
                IsPaid=x.IsPaid,
                IsCanceled=x.IsCanceled,
                orderItems= ProjectOrderItems(x.OrderItems)
            }).FirstOrDefault(x => x.UserId == userId && !x.IsPaid && !x.IsCanceled);

        }

        private List<OrderItemViewModel> ProjectOrderItems(List<OrderItem> orderItems)
        {
            var projectedOrderItems = orderItems.Select(x => new OrderItemViewModel()
            {
                SellerProductId = x.SellerProductId,
                UnitPrice = x.UnitPrice,
                Count = x.Count,
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
    }
}
