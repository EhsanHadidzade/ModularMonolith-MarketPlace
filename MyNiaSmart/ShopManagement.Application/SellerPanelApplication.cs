using _0_Framework.Contract;
using _0_Framework.Utilities;
//using AccountManagement.Application.Contract.UserPersonalityRequest;
//using AccountManagement.Domain.UserPersonalityRequestAgg;
using ShopManagement.Application.Contract.SellerPanel;
using ShopManagement.Domain.SellerPanelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SellerPanelApplication : ISellerPanelApplication
    {
        private readonly ISellerPanelRepository _sellerPanelRepository;
        //private readonly IUserPersonalityRequestApplication _userPersonalityRequestApplication;
        private readonly IAuthHelper _authHelper;

        public SellerPanelApplication(ISellerPanelRepository sellerPanelRepository, IAuthHelper authHelper)
        {
            _sellerPanelRepository = sellerPanelRepository;
            _authHelper = authHelper;
        }

        public void CancelByAdmin(long sellerPanelId)
        {
            var sellerPanel = _sellerPanelRepository.GetById(sellerPanelId);
            sellerPanel.ConfirmByAdmin();
        }

        public void ConfirmByAdmin(long sellerPanelId)
        {
            var sellerPanel = _sellerPanelRepository.GetById(sellerPanelId);
            sellerPanel.ConfirmByAdmin();
            _sellerPanelRepository.Savechange();
        }

        public OperationResult Create(CreateSellerPanel command)
        {
            var operation = new OperationResult();
            if (!string.IsNullOrWhiteSpace(command.CompanyName))
            {
                if (_sellerPanelRepository.IsExist(x => x.CompanyName == command.CompanyName))
                    return operation.Failed("این نام قبلا ثبت شده است . از نام دیگری استفاده نمایید");
            }

            if (!string.IsNullOrWhiteSpace(command.StoreName))
            {
                if (_sellerPanelRepository.IsExist(x => x.CompanyName == command.CompanyName))
                    return operation.Failed("این نام قبلا ثبت شده است . از نام دیگری استفاده نمایید");
            }

            if (_sellerPanelRepository.IsExist(x => x.UserId == command.UserId))
                return operation.Failed("شما قبلا درخواست برای ایجاد پنل فروشندگی پر کرده اید");

            if (command.UserId == 0)
                return operation.Failed("کاربر قابل شناسایی نیست. لطفا با حساب کاربری معتبر وارد شوید");

            var sellerPanel = new SellerPanel(command.Address, command.SellerMobileNumber,
                command.BuyersCategory, command.CanMarketerSee, command.IsUserLegal, command.StoreName,
                command.CompanyName, command.CompanyRegistrationCode, command.CompanyEconomicCode,
                command.UserId, command.Capital, command.City, command.DeliveryDurationForCity,
                command.DeliveryDurationForCapital, command.DeliveryDurationForOther, command.WarrantyTypeId, command.WarrantyAmount);
            _sellerPanelRepository.Create(sellerPanel);
            _sellerPanelRepository.Savechange();

            return operation.Succedded("درخواست شما با موفقیت ارسال و در حال بررسی میباشد. نتیجه آن در پنل کاربریتان قابل مشاهده خواهد بود  ");
        }

        public EditSellerPanel GetDetails(long id)
        {
            return _sellerPanelRepository.GetDetails(id);
        }

        public List<SellerPanelViewModel> GetList()
        {
            return _sellerPanelRepository.GetList();
        }

        public List<SellerPanelForMainShopViewModel> GetNormalSellersWhoSellingThisProduct(string slug, int filterType)
        {
            return _sellerPanelRepository.GetNormalSellersWhoSellingThisProduct(slug, filterType);
        }

        public long GetSellerPanelIdByUserId(long userId)
        {
            return _sellerPanelRepository.GetSellerPanelIdByUserId(userId);
        }

        public List<SellerPanelForMainShopViewModel> GetSpecialSellersWhoSellingThisProduct(string slug, int filterType)
        {
            return _sellerPanelRepository.GetSpecialSellersWhoSellingThisProduct(slug, filterType);
        }

        public bool HasUserRequestedForSellerPanel(long userId)
        {
            return _sellerPanelRepository.HasUserRequestedForSellerPanel(userId);
        }

        public bool HasUserSellerPanelConfirmedByAdmin(long userId)
        {
            return _sellerPanelRepository.HasUserSellerPanelConfirmedByAdmin(userId);
        }
    }
}
