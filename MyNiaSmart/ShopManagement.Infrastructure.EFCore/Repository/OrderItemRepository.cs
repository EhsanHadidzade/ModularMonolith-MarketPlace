using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.OrderItem;
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
    public class OrderItemRepository : BaseRepository<long, OrderItem>, IOrderItemRepository
    {
        private readonly ShopContext _shopContext;
        private readonly ISellerProductRepository _sellerProductRepository;
        private readonly ISellerPanelRepository _sellerPanelRepository;
        private readonly IProductRepository _productRepository;

        public OrderItemRepository(ShopContext shopContext, ISellerProductRepository sellerProductRepository,
            IProductRepository productRepository, ISellerPanelRepository sellerPanelRepository) : base(shopContext)
        {
            _shopContext = shopContext;
            _sellerProductRepository = sellerProductRepository;
            _productRepository = productRepository;
            _sellerPanelRepository = sellerPanelRepository;
        }

        public List<OrderItemViewModel> GetListByOrderId(long orderId)
        {
            var orderItems = _shopContext.OrderItems.Select(x => new OrderItemViewModel
            {
                Id = x.Id,
                OrderId = x.OrderId,
                SellerProductId = x.SellerProductId,
                UnitPrice = x.UnitPrice,
                Count = x.Count
            }).Where(x => x.OrderId == orderId).ToList();

            foreach (var item in orderItems)
            {
                var productId = _sellerProductRepository.GetProductIdBySellerProductId(item.SellerProductId);
                var product = _productRepository.GetInfoById(productId);
                item.SellerProductTitle = product.FarsiTitle;
                item.PictureURL = product.PictureURL;
                item.SellerShopName = _sellerPanelRepository.GetShopNameBySellerProductId(item.SellerProductId);
            }

            return orderItems;
        }

        public List<OrderItemViewModel> GetListWhichRelatedToSellerByOrderIdAndSellerPanelId(long orderId, long sellerPanelId)
        {
            var orderItems = new List<OrderItemViewModel>();
            var sellerProductIds = _sellerProductRepository.GetIdsBySellerPanelId(sellerPanelId);
            foreach (var id in sellerProductIds)
            {
                var orderItem = _shopContext.OrderItems.Select(x => new OrderItemViewModel
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    SellerProductId = x.SellerProductId,
                    UnitPrice = x.UnitPrice,
                    Count = x.Count
                }).FirstOrDefault(x => x.OrderId == orderId && x.SellerProductId == id);

                if (orderItem != null)
                    orderItems.Add(orderItem);
            }

            foreach (var item in orderItems)
            {
                var sellerProduct = _sellerProductRepository.GetSomeInfoById(item.SellerProductId);
                //var productId = _sellerProductRepository.GetProductIdBySellerProductId(item.SellerProductId);
                var product = _productRepository.GetInfoById(sellerProduct.ProductId);
                item.SellerProductTitle = product.FarsiTitle;
                item.PictureURL = product.PictureURL;
                item.SellerShopName = _sellerPanelRepository.GetShopNameBySellerProductId(item.SellerProductId);
                item.SellerDeliveryDurationForCity=sellerProduct.DeliveryDurationForCity;
                item.SellerDeliveryDurationForCapital=sellerProduct.DeliveryDurationForCapital;
                item.SellerDeliveryDurationForOther=sellerProduct.DeliveryDurationForOther;
            }

            return orderItems;
        }
    }
}
