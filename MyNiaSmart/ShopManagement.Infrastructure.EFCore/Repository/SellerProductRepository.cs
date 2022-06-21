using _0_Framework.Contract;
using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.SellerProduct;
using ShopManagement.Application.Contract.SellerProductMedia;
using ShopManagement.Domain.SellerPanelAgg;
using ShopManagement.Domain.SellerProductAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SellerProductRepository : BaseRepository<long, SellerProduct>, ISellerProductRepository
    {
        private readonly ShopContext _shopContext;
        private readonly IAuthHelper _authHelper;
        private readonly ISellerPanelRepository _sellerPanelRepository;

        public SellerProductRepository(ShopContext shopContext, IAuthHelper authHelper,
            ISellerPanelRepository sellerPanelRepository) : base(shopContext)
        {
            _shopContext = shopContext;
            _authHelper = authHelper;
            _sellerPanelRepository = sellerPanelRepository;
        }
        public List<SellerProductViewModel> GetList()
        {
            var products = _shopContext.SellerProducts.Include(x => x.Product).Include(x => x.SellerPanel).Select(x => new SellerProductViewModel
            {
                Id = x.Id,
                IsConfirmedByAdmin = x.isConfirmedByAdmin,
                Price = x.Price,
                ProductId = x.ProductId,
                ProductTitle = x.Product.FarsiTitle,
                PictureUrl = x.Product.Picture,
                SellerPanelStoreName = x.SellerPanel.StoreName,
                SellerPanelCompanyName = x.SellerPanel.CompanyName,
                CreationDate = x.CreationDate.ToFarsi()
            }).OrderByDescending(x => x.Id).ToList();

            return products;
        }
        public List<SellerProductViewModel> GetListBySellerPanelId(long sellerpanelId)
        {
            var products = _shopContext.SellerProducts.Include(x => x.Product).Include(x => x.SellerPanel).Select(x => new SellerProductViewModel
            {
                Id = x.Id,
                IsConfirmedByAdmin = x.isConfirmedByAdmin,
                SellerPanelId = x.SellerPanelId,
                Price = x.Price,
                ProductId = x.ProductId,
                ProductTitle = x.Product.FarsiTitle,
                PictureUrl = x.Product.Picture,
                SellerPanelStoreName = x.SellerPanel.StoreName,
                SellerPanelCompanyName = x.SellerPanel.CompanyName,
                CreationDate = x.CreationDate.ToFarsi()
            }).Where(x => x.SellerPanelId == sellerpanelId).OrderByDescending(x => x.Id).ToList();

            return products;
        }

        public EditSellerProduct GetDetails(long sellerProductId)
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var sellerProduct = _shopContext.SellerProducts.Include(x => x.Product).Select(x => new EditSellerProduct
            {
                Id = x.Id,
                BuyersCategory = x.BuyersCategory,
                CanMarketerSee = x.CanMarketerSee,
                DeliveryDurationForCapital = x.DeliveryDurationForCapital,
                DeliveryDurationForCity = x.DeliveryDurationForCity,
                DeliveryDurationForOther = x.DeliveryDurationForOther,
                Description = x.Description,
                MarketerShareAmount = x.MarketerShareAmount,
                MarketerSharePercent = x.MarketerSharePercent,
                Price = x.Price,
                ProductId = x.ProductId,
                ProductTitle = x.Product.FarsiTitle,
                SellerPanelId = x.SellerPanelId,
                WarrantyAmount = x.WarrantyAmount,
                WarrantyTypeId = x.WarrantyTypeId
            }).FirstOrDefault(x => x.Id == sellerProductId);

            sellerProduct.SelectedMedias = _shopContext.SellerProductMedias
                .Select(x => new SellerGalleryViewModel
                {
                    MediaURL = x.MediaURL,
                    Id = x.Id,
                    SellerProductId = x.SellerProductId,
                    UserId = x.UserId
                }).Where(x => x.SellerProductId == sellerProduct.Id && x.UserId == userId).ToList();

            return sellerProduct;
        }

        public EditSellerProduct GetDetailsBySellerPanelIdAndProductId(long sellerPaneId, long productId)
        {
            //To Do Find Exact SellerProduct then use info to show for sellerProductDetailsView
            var userId = _sellerPanelRepository.GetUserIdBySellerPanelId(sellerPaneId);
            var sellerProduct = _shopContext.SellerProducts.Include(x => x.Product).Select(x => new EditSellerProduct
            {
                Id = x.Id,
                BuyersCategory = x.BuyersCategory,
                CanMarketerSee = x.CanMarketerSee,
                DeliveryDurationForCapital = x.DeliveryDurationForCapital,
                DeliveryDurationForCity = x.DeliveryDurationForCity,
                DeliveryDurationForOther = x.DeliveryDurationForOther,
                Description = x.Description,
                MarketerShareAmount = x.MarketerShareAmount,
                MarketerSharePercent = x.MarketerSharePercent,
                Price = x.Price,
                ProductId = x.ProductId,
                ProductTitle = x.Product.FarsiTitle,
                SellerPanelId = x.SellerPanelId,
                WarrantyAmount = x.WarrantyAmount,
                WarrantyTypeId = x.WarrantyTypeId
            }).FirstOrDefault(x => x.SellerPanelId == sellerPaneId && x.ProductId == productId);

            sellerProduct.SelectedMedias = _shopContext.SellerProductMedias
              .Select(x => new SellerGalleryViewModel
              {
                  MediaURL = x.MediaURL,
                  Id = x.Id,
                  SellerProductId = x.SellerProductId,
                  IsMediaImage = x.IsMediaImage,
                  UserId = x.UserId
              }).Where(x => x.SellerProductId == sellerProduct.Id && x.UserId == userId).ToList();

            return sellerProduct;

        }
    }
}
