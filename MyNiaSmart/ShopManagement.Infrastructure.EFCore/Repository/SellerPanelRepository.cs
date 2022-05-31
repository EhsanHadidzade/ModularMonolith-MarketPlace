using _0_Framework.Infrastructure;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contract.SellerPanel;
using ShopManagement.Domain.SellerPanelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SellerPanelRepository:BaseRepository<long,SellerPanel>,ISellerPanelRepository
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
            return _shopContext.SellerPanels.Select(x=>new EditSellerPanel
            {
                Id=x.Id,
                Address=x.Address,
                BuyersCategory=x.BuyersCategory,
                CanMarketerSee=x.CanMarketerSee,
                Capital=x.Capital,
                City=x.City,
                DeliveryDurationForCity=x.DeliveryDurationForCity,
                DeliveryDurationForCapital=x.DeliveryDurationForCapital,
                DeliveryDurationForOther=x.DeliveryDurationForOther,
                WarrantyTypeId=x.WarrantyTypeId,
                WarrantyAmount=x.WarrantyAmount,
                CompanyEconomicCode=x.CompanyEconomicCode,
                CompanyName=x.CompanyName,
                CompanyRegistrationCode=x.CompanyRegistrationCode,
                IsUserLegal=x.IsUserLegal,
                SellerMobileNumber=x.SellerMobileNumber,
                StoreName=x.StoreName,
                UserId=x.UserId
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<SellerPanelViewModel> GetList()
        {
            return _shopContext.SellerPanels.Select(x=>new SellerPanelViewModel
            {
                Id = x.Id,
                SellerFullName=_userRepository.GetFullNameByUserId(x.UserId),
                StoreName=x.StoreName,
                UserId=x.UserId,
                Capital=x.Capital,
                City=x.City,
                CompanyName=x.CompanyName,
                Islegal=x.IsUserLegal,
                IsConfirmByAdmin=x.IsConfirmedByAdmin
            }).OrderByDescending(x=>x.Id).ToList();
        }

        public bool HasUserRequestedForSellerPanel(long userId)
        {
            return _shopContext.SellerPanels.Any(x => x.UserId == userId);
        }

        public bool HasUserSellerPanelConfirmedByAdmin(long userId)
        {
            var sellerPanelRequest=_shopContext.SellerPanels.FirstOrDefault(x=>x.UserId==userId && x.IsConfirmedByAdmin);
            return sellerPanelRequest != null;
        }
    }
}
