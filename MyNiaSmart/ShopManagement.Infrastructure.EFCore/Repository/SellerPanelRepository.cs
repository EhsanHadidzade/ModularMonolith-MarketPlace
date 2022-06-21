using _0_Framework.Infrastructure;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.SellerPanel;
using ShopManagement.Domain.SellerPanelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SellerPanelRepository : BaseRepository<long, SellerPanel>, ISellerPanelRepository
    {
        private readonly ShopContext _shopContext;
        private readonly IUserRepository _userRepository;


        public SellerPanelRepository(ShopContext shopcontext, IUserRepository userRepository) : base(shopcontext)
        {
            _shopContext = shopcontext;
            _userRepository = userRepository;
        }

        public EditSellerPanel GetDetails(long id)
        {
            return _shopContext.SellerPanels.Select(x => new EditSellerPanel
            {
                Id = x.Id,
                Address = x.Address,
                BuyersCategory = x.BuyersCategory,
                CanMarketerSee = x.CanMarketerSee,
                Capital = x.Capital,
                City = x.City,
                DeliveryDurationForCity = x.DeliveryDurationForCity,
                DeliveryDurationForCapital = x.DeliveryDurationForCapital,
                DeliveryDurationForOther = x.DeliveryDurationForOther,
                WarrantyTypeId = x.WarrantyTypeId,
                WarrantyAmount = x.WarrantyAmount,
                CompanyEconomicCode = x.CompanyEconomicCode,
                CompanyName = x.CompanyName,
                CompanyRegistrationCode = x.CompanyRegistrationCode,
                IsUserLegal = x.IsUserLegal,
                SellerMobileNumber = x.SellerMobileNumber,
                StoreName = x.StoreName,
                UserId = x.UserId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SellerPanelViewModel> GetList()
        {
            return _shopContext.SellerPanels.Select(x => new SellerPanelViewModel
            {
                Id = x.Id,
                SellerFullName = _userRepository.GetFullNameByUserId(x.UserId),
                StoreName = x.StoreName,
                UserId = x.UserId,
                Capital = x.Capital,
                City = x.City,
                CompanyName = x.CompanyName,
                Islegal = x.IsUserLegal,
                IsConfirmByAdmin = x.IsConfirmedByAdmin,
                IsSpecial=x.IsSpecial
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<SellerPanelForMainShopViewModel> GetNormalSellersWhoSellingThisProduct(string slug, int filterType)
        {
            var product = _shopContext.Products.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Slug == slug);
            if (product == null)
                return new List<SellerPanelForMainShopViewModel>();

            var productId = product.Id;
            var sellerPanelsWhoSellingThis = _shopContext.SellerProducts.Include(x => x.SellerPanel).Select(x => new SellerPanelForMainShopViewModel
            {
                Id = x.SellerPanel.Id,
                ProductId = x.ProductId,
                IsUserLegal = x.SellerPanel.IsUserLegal,
                IsSellerSpecial = x.SellerPanel.IsSpecial,
                isConfirmedByAdmin = x.isConfirmedByAdmin,
                CompanyName = x.SellerPanel.CompanyName,
                StoreName = x.SellerPanel.StoreName,
                UserId = x.SellerPanel.UserId,
                SpecificProductPrice = x.Price,
                WarrantyTypeId = x.WarrantyTypeId,
                WarrantyAmount = x.WarrantyAmount,
            }).Where(s => s.ProductId == productId && s.isConfirmedByAdmin && !s.IsSellerSpecial).ToList();

            if (sellerPanelsWhoSellingThis.Count() == 0)
                return new List<SellerPanelForMainShopViewModel>();

            foreach (var sellerPanel in sellerPanelsWhoSellingThis)
            {
                sellerPanel.Grade = _userRepository.GetGradeByUserId(sellerPanel.UserId);
                sellerPanel.SellerFullName = _userRepository.GetFullNameByUserId(sellerPanel.UserId);
            }

            if (filterType == 1)
                return sellerPanelsWhoSellingThis.OrderByDescending(x => x.SpecificProductPrice).ToList();

            if (filterType == 2)
                return sellerPanelsWhoSellingThis.OrderByDescending(x => x.WarrantyTypeId).OrderByDescending(x => x.WarrantyAmount).ToList();

            return sellerPanelsWhoSellingThis.OrderByDescending(x => x.Grade).ToList();

        }

        public List<SellerPanelForMainShopViewModel> GetSpecialSellersWhoSellingThisProduct(string slug, int filterType)
        {
            var product = _shopContext.Products.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Slug == slug);
            if (product == null)
                return new List<SellerPanelForMainShopViewModel>();

            var productId = product.Id;
            var sellerPanelsWhoSellingThis = _shopContext.SellerProducts.Include(x => x.SellerPanel).Select(x => new SellerPanelForMainShopViewModel
            {
                Id = x.SellerPanel.Id,
                ProductId = x.ProductId,
                IsUserLegal = x.SellerPanel.IsUserLegal,
                IsSellerSpecial = x.SellerPanel.IsSpecial,
                isConfirmedByAdmin = x.isConfirmedByAdmin,
                CompanyName = x.SellerPanel.CompanyName,
                StoreName = x.SellerPanel.StoreName,
                UserId = x.SellerPanel.UserId,
                SpecificProductPrice = x.Price,
                WarrantyTypeId = x.WarrantyTypeId,
                WarrantyAmount = x.WarrantyAmount,
            }).Where(s => s.ProductId == productId && s.isConfirmedByAdmin && s.IsSellerSpecial).ToList();

            if (sellerPanelsWhoSellingThis.Count() == 0)
                return new List<SellerPanelForMainShopViewModel>();

            foreach (var sellerPanel in sellerPanelsWhoSellingThis)
            {
                sellerPanel.Grade = _userRepository.GetGradeByUserId(sellerPanel.UserId);
                sellerPanel.SellerFullName = _userRepository.GetFullNameByUserId(sellerPanel.UserId);
            }

            if (filterType == 1)
                return sellerPanelsWhoSellingThis.OrderByDescending(x => x.SpecificProductPrice).ToList();

            if (filterType == 2)
                return sellerPanelsWhoSellingThis.OrderByDescending(x => x.WarrantyTypeId).OrderByDescending(x => x.WarrantyAmount).ToList();

            return sellerPanelsWhoSellingThis.OrderByDescending(x => x.Grade).ToList();
        }

        public long GetSellerPanelIdByUserId(long userId)
        {
            var sellerPanel = _shopContext.SellerPanels.Select(x => new { x.Id, x.UserId }).FirstOrDefault(x => x.UserId == userId);
            return sellerPanel.Id;
        }

        public bool HasUserRequestedForSellerPanel(long userId)
        {
            return _shopContext.SellerPanels.Any(x => x.UserId == userId);
        }

        public bool HasUserSellerPanelConfirmedByAdmin(long userId)
        {
            var sellerPanelRequest = _shopContext.SellerPanels.FirstOrDefault(x => x.UserId == userId && x.IsConfirmedByAdmin);
            return sellerPanelRequest != null;
        }

        public long GetIdByName(string storeName)
        {
            var sellerPanel = _shopContext.SellerPanels.Select(x => new
            {
                x.Id,
                x.StoreName,
                x.CompanyName
            }).FirstOrDefault(x => x.CompanyName == storeName || x.StoreName == storeName);

            return sellerPanel.Id;
        }

        public long GetUserIdBySellerPanelId(long sellerPanelId)
        {
            var sellerPanel= _shopContext.SellerPanels.Select(x => new { x.Id, x.UserId }).FirstOrDefault(x=>x.Id==sellerPanelId);
            return sellerPanel.UserId;
        }
    }
}
