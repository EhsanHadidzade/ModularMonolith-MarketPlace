using _0_Framework.Contract;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.UserPersonalityRequest;
using AccountManagement.Domain.UserPersonalityRequestAgg;
using ShopManagement.Application.Contract.SellerPanel;
using ShopManagement.Domain.SellerPanel;
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
        private readonly IUserPersonalityRequestApplication _userPersonalityRequestApplication;
        private readonly IAuthHelper _authHelper;

        public SellerPanelApplication(ISellerPanelRepository sellerPanelRepository, IAuthHelper authHelper,
            IUserPersonalityRequestApplication userPersonalityRequestApplication)
        {
            _sellerPanelRepository = sellerPanelRepository;
            _authHelper = authHelper;
            _userPersonalityRequestApplication = userPersonalityRequestApplication;
        }

        public OperationResult Create(CreateSellerPanel command, List<long> userPersonalityRequestsIds)
        {
            var operation = new OperationResult();
            if (_sellerPanelRepository.IsExist(x => x.UserId == command.UserId))
                return operation.Failed("شما قبلا درخواست برای ایجاد پنل فروشندگی پر کرده اید");

            if (command.UserId == 0)
                return operation.Failed("کاربر قابل شناسایی نیست. لطفا با حساب کاربری معتبر وارد شوید");

            var sellerPanel = new SellerPanel(command.StoreName, command.Address, command.StoreMobileNumber,
                command.BuyersCategory, command.CanMarketerSee, command.UserId);
            _sellerPanelRepository.Create(sellerPanel);
            _sellerPanelRepository.Savechange();

            var createuserPersonality = new CreateUserPersonalityRequestForSellerPanel() 
            {
                RequestedPersonalityIds = userPersonalityRequestsIds,
                UserId=command.UserId
            };
            _userPersonalityRequestApplication.Create(createuserPersonality);
            //in create method , saving is done

            return operation.Succedded("درخواست شما با موفقیت ارسال و در حال بررسی میباشد. نتیجه آن را  پنل کاربریتان قابل مشاهده خواهد بود  ");


        }

        public List<SellerPanelViewModel> GetList()
        {
            return _sellerPanelRepository.GetList();
        }
    }
}
