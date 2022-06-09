using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.SellerProduct;
using ShopManagement.Domain.SellerProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SellerProductRepository:BaseRepository<long,SellerProduct>,ISelleProductRepository
    {
        private readonly ShopContext _shopContext;

        public SellerProductRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
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
                SellerPanelId=x.SellerPanelId,
                Price = x.Price,
                ProductId = x.ProductId,
                ProductTitle = x.Product.FarsiTitle,
                PictureUrl = x.Product.Picture,
                SellerPanelStoreName = x.SellerPanel.StoreName,
                SellerPanelCompanyName = x.SellerPanel.CompanyName,
                CreationDate = x.CreationDate.ToFarsi()
            }).Where(x=>x.SellerPanelId==sellerpanelId).OrderByDescending(x => x.Id).ToList();

            return products;
        }

        public EditSellerProduct GetDetails(long sellerProductId)
        {
            return _shopContext.SellerProducts.Include(x => x.Product).Select(x => new EditSellerProduct
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
        }
     
      
    }
}
