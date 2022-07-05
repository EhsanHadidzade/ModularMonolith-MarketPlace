using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.OrderItem;
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

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderItemRepository : BaseRepository<long, OrderItem>, IOrderItemRepository
    {
        private readonly ShopContext _shopContext;
        private readonly IProductRepository _productRepository;
        private readonly ITransitionRepository _transitionRepository;
        private readonly ISellerPanelRepository _sellerPanelRepository;
        private readonly ISellerProductRepository _sellerProductRepository;

        public OrderItemRepository(ShopContext shopContext, ISellerProductRepository sellerProductRepository,
            IProductRepository productRepository, ISellerPanelRepository sellerPanelRepository,
            ITransitionRepository transitionRepository) : base(shopContext)
        {
            _shopContext = shopContext;
            _sellerProductRepository = sellerProductRepository;
            _productRepository = productRepository;
            _sellerPanelRepository = sellerPanelRepository;
            _transitionRepository = transitionRepository;
        }

        public List<OrderItemViewModel> GetListByOrderId(long orderId)
        {
            var orderItems = _shopContext.OrderItems.Select(x => new OrderItemViewModel
            {
                Id = x.Id,
                OrderId = x.OrderId,
                SellerProductId = x.SellerProductId,
                UnitPrice = x.UnitPrice,
                Count = x.Count,
                TransitionId = x.TransitionId
            }).Where(x => x.OrderId == orderId).ToList();

            foreach (var item in orderItems)
            {
                var productId = _sellerProductRepository.GetProductIdBySellerProductId(item.SellerProductId);
                var product = _productRepository.GetInfoById(productId);
                var transition=_transitionRepository.GetById(item.TransitionId);
                item.SellerProductTitle = product.FarsiTitle;
                item.PictureURL = product.PictureURL;
                item.SellerShopName = _sellerPanelRepository.GetShopNameBySellerProductId(item.SellerProductId);

                if (transition != null)
                {
                    item.TransitionTrackingNumber = transition?.TrackingNumber;
                    item.CalculatedDeliveryduration = transition.Duration;
                }
            }
            return orderItems;
        }
        public List<OrderItemViewModel> GetListByTransitionId(long transitionId)
        {
            var orderItems = _shopContext.OrderItems.Select(x => new OrderItemViewModel
            {
                Id = x.Id,
                OrderId = x.OrderId,
                SellerProductId = x.SellerProductId,
                UnitPrice = x.UnitPrice,
                Count = x.Count,
                TransitionId = x.TransitionId
            }).Where(x => x.TransitionId == transitionId).ToList();

            foreach (var item in orderItems)
            {
                var productId = _sellerProductRepository.GetProductIdBySellerProductId(item.SellerProductId);
                var product = _productRepository.GetInfoById(productId);
                item.SellerProductTitle = product.FarsiTitle;
                item.PictureURL = product.PictureURL;
                item.SellerShopName = _sellerPanelRepository.GetShopNameBySellerProductId(item.SellerProductId);

                item.TransitionTrackingNumber = _transitionRepository.GetTrackingNumberById(item.TransitionId);
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
                    Count = x.Count,
                    TransitionId = x.TransitionId
                }).FirstOrDefault(x => x.OrderId == orderId && x.SellerProductId == id);

                if (orderItem != null)
                    orderItems.Add(orderItem);
            }

            foreach (var item in orderItems)
            {
                //arrange
                var sellerProduct = _sellerProductRepository.GetSomeInfoById(item.SellerProductId);
                var product = _productRepository.GetInfoById(sellerProduct.ProductId);
                var transition = _transitionRepository.GetById(item.TransitionId);

                //act
                item.SellerProductTitle = product.FarsiTitle;
                item.PictureURL = product.PictureURL;
                //act
                item.SellerShopName = _sellerPanelRepository.GetShopNameBySellerProductId(item.SellerProductId);
                item.SellerDeliveryDurationForCity = sellerProduct.DeliveryDurationForCity;
                item.SellerDeliveryDurationForCapital = sellerProduct.DeliveryDurationForCapital;
                item.SellerDeliveryDurationForOther = sellerProduct.DeliveryDurationForOther;
                item.SellerProductPrice=sellerProduct.Price;
                //act
                if (transition != null)
                {
                    item.TransitionTrackingNumber = transition.TrackingNumber;
                    item.CalculatedDeliveryduration = transition.Duration;
                }
                
            }

            return orderItems;
        }
    }
}
