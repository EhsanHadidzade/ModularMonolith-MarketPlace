using _0_Framework.Contract;
using _0_Framework.Utilities;
using _0_Framework.Utilities.ZarinPal;
using _0_MyNiaSmartQuery.Contract.User;
using AccountManagement.Application.Contract.BusinessWallet;
using AccountManagement.Application.Contract.PersonalityType;
using AccountManagement.Application.Contract.PersonalWallet;
using AccountManagement.Application.Contract.PersonalWalletOperation;
using AccountManagement.Application.Contract.RejectionReason;
using AccountManagement.Application.Contract.RoleType;
using AccountManagement.Application.Contract.UpAccountRequest;
using AccountManagement.Application.Contract.UpAccountRequestRejectionReason;
using AccountManagement.Application.Contract.User;
using AccountManagement.Application.Contract.UserAddress;
using AccountManagement.Application.Contract.UserCooperationRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.OrderItem;
using ShopManagement.Application.Contract.SellerPanel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [TempData]
        public static string message { get; set; }
        public static string withdrawResult { get; set; }
        public static string transferResult { get; set; }

        private readonly IUserQuery _userQuery;
        private readonly IAuthHelper _authHelper;
        private readonly IUserApplication _userApplication;
        private readonly IUPAccountRequestApplication _upAccountRequestApplication;
        private readonly IRejectionReasonApplication _rejectionReasonApplication;
        private readonly IUpAccountRequestRejectionReasonApplication _upAccountRequestRejectionReasonApplication;
        private readonly IPersonalWalletApplication _personalWalletApplication;
        private readonly IBusinessWalletApplication _businessWalletApplication;
        private readonly IPersonalWalletOperationApplication _personalWalletOperationApplication;
        private readonly IZarinPalFactory _zarinPalFactory;
        public readonly IUserCooperationRequestApplication _UserCooperationRequestApplication;
        private readonly IRoleTypeApplication _roleTypeApplication;
        private readonly ISellerPanelApplication _sellerPanelApplication;
        private readonly IPersonalityTypeApplication _personalityTypeApplication;
        private readonly IUserAddressApplication _userAddressApplication;
        private readonly IOrderApplication _orderApplication;
        private readonly IOrderItemApplication _orderItemApplication;

        public UserController(IUserQuery userQuery, IAuthHelper authHelper, IUserApplication userApplication,
            IUPAccountRequestApplication upAccountRequestApplication, IRejectionReasonApplication rejectionReasonApplication,
            IUpAccountRequestRejectionReasonApplication upAccountRequestRejectionReasonApplication,
            IPersonalWalletApplication personalWalletApplication, IBusinessWalletApplication businessWalletApplication,
            IPersonalWalletOperationApplication personalWalletOperationApplication, IZarinPalFactory zarinPalFactory,
            IUserCooperationRequestApplication userCooperationRequestApplication, IRoleTypeApplication roleTypeApplication,
            ISellerPanelApplication sellerPanelApplication, IPersonalityTypeApplication personalityTypeApplication,
            IUserAddressApplication userAddressApplication, IOrderApplication orderApplication, IOrderItemApplication orderItemApplication)
        {
            _userQuery = userQuery;
            _authHelper = authHelper;
            _userApplication = userApplication;
            _upAccountRequestApplication = upAccountRequestApplication;
            _rejectionReasonApplication = rejectionReasonApplication;
            _upAccountRequestRejectionReasonApplication = upAccountRequestRejectionReasonApplication;
            _personalWalletApplication = personalWalletApplication;
            _businessWalletApplication = businessWalletApplication;
            _personalWalletOperationApplication = personalWalletOperationApplication;
            _zarinPalFactory = zarinPalFactory;
            _UserCooperationRequestApplication = userCooperationRequestApplication;
            _roleTypeApplication = roleTypeApplication;
            _sellerPanelApplication = sellerPanelApplication;
            _personalityTypeApplication = personalityTypeApplication;
            _userAddressApplication = userAddressApplication;
            _orderApplication = orderApplication;
            _orderItemApplication = orderItemApplication;
        }

        #region for users To Edit profile details in their profile
        public IActionResult UserProfile()
        {
            if (!string.IsNullOrWhiteSpace(message))
                ViewData["message"] = message;

            long userId = _authHelper.CurrentAccountInfo().Id;
            var userInfo = _userQuery.GetUserInfo(userId);
            var userAddresses = _userAddressApplication.GetListByUserId(userId);
            var EditUser = _userApplication.GetDetails(userId);
            //var RoleTypesWithRoles = _roleTypeApplication.GetList();
            var PersonalityTypesWithPersonalities = _personalityTypeApplication.GetList();
            var model = new Tuple<UserInfoQueryModel, List<UserAddressViewModel>, EditUser, List<PersonalityTypeViewModel>>(userInfo, userAddresses, EditUser, PersonalityTypesWithPersonalities);
            return View(model);
        }

        [HttpPost]
        public IActionResult _UserProfileEdit(EditUser command)
        {
            var result = _userApplication.Edit(command);
            UserController.message = result.Message;
            return RedirectToAction("userProfile");
        }

        [HttpPost]
        public IActionResult CooperationRequest(List<long> PersonalityList)
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var command = new CreateUserCooperationRequest
            {
                UserId = userId,
                SelectedPersonalityIds = PersonalityList
            };
            var result = _UserCooperationRequestApplication.CreateUserCoopeartionRequest(command);
            UserController.message = result.Message;
            return RedirectToAction("userProfile");

        }
        #endregion

        #region User Addresses Management
        public IActionResult CreateAddress()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult CreateAddress(CreateUserAddress command)
        {
            long userId = _authHelper.CurrentAccountInfo().Id;
            command.UserId = userId;
            var result = _userAddressApplication.Create(command);
            UserController.message = result.Message;
            return RedirectToAction("userProfile");
        }

        public IActionResult EditAddress(long id)
        {
            var userAddress = _userAddressApplication.GetDetails(id);
            return PartialView(userAddress);

        }

        [HttpPost]
        public IActionResult EditAddress(EditUserAddress command)
        {
            var result = _userAddressApplication.Edit(command);
            UserController.message = result.Message;
            return RedirectToAction("userProfile");
        }


        #endregion

        #region CreateUpAccountRequest

        public IActionResult UpgradeAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpgradeAccount(CreateUpAccountRequest command)
        {
            var result = _upAccountRequestApplication.Create(command);
            if (!result.IsSuccedded)
            {
                ViewData["UpRequestResult"] = result.Message;
                return View(command);
            }
            UserController.message = result.Message;
            return RedirectToAction("UserProfile");
        }
        #endregion

        #region EditUpAccountRequest

        public IActionResult EditUpgradeAccount(long id)
        {
            //to find if request is rejected by admin with reasons
            bool IsRequestRejected = _upAccountRequestRejectionReasonApplication.HasRequestRejectedByReason(id);
            if (IsRequestRejected)
                ViewData["IsRequestRejected"] = IsRequestRejected;

            var upAccountRequest = _upAccountRequestApplication.GetDetails(id);
            return View(upAccountRequest);
        }

        [HttpPost]
        public IActionResult EditUpgradeAccount(EditUpAccountRequest command)
        {
            _upAccountRequestApplication.Edit(command);
            return Redirect("/");
        }
        #endregion

        #region To Show client the reasons that admin rejected their up account request
        public IActionResult ShowRejectionReason(long id)
        {
            var reasons = _rejectionReasonApplication.GetReasonsOfSpecificUpAccountRequest(id);
            return PartialView(reasons);
        }
        #endregion

        #region Personal wallets
        public IActionResult Wallet()
        {
            if (!string.IsNullOrWhiteSpace(transferResult))
                ViewData["operationResult"] = transferResult;

            if (!string.IsNullOrWhiteSpace(withdrawResult))
                ViewData["operationResult"] = withdrawResult;

            var userId = _authHelper.CurrentAccountInfo().Id;
            var userPersonalWallet = _personalWalletApplication.GetWalletByUserId(userId);
            var userBusinessWallet = _businessWalletApplication.GetWalletByUserId(userId);
            var model = new Tuple<PersonalWalletViewModel, BusinessWalletViewModel>(userPersonalWallet, userBusinessWallet);

            //personalWalletChart
            var labels = new List<string>();
            var datas = new List<long>();
            foreach (var item in userPersonalWallet.PersonalWalletCharts)
            {
                labels.Add(item.BalanceUpdateDate);
                datas.Add(item.Balance);
            }
            ViewData["personalWalletChartLabels"] = labels;
            ViewData["personalWalletChartDatas"] = datas;

            #region PersonalWalletChart

            #endregion
            return View(model);
        }
        #endregion

        #region DepositeOperation
        public IActionResult CashDeposite(long id)
        {
            ViewData["personalWalletId"] = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult CashDeposite(ChargePersonalWallet command)
        {
            var personalWalletOperationId = _personalWalletOperationApplication.ChargePersonalWallet(command);
            var userMobile = _authHelper.CurrentAccountInfo().Mobile;
            var paymentResponse = _zarinPalFactory.CreatePaymentRequest(command.Amount, userMobile,
                PersonalWalletOperationTitle.Deposite, personalWalletOperationId);


            return Redirect($"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
        }
        #endregion

        #region CashTransferOperation

        public IActionResult CashTransfer(long id)
        {
            ViewData["personalWalletId"] = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult CashTransfer(TransferToAnotherWallet command)
        {
            var personalWalletBalance = _personalWalletApplication.GetBalanceByPersonalWalletId(command.PersonalWalletId);
            if (personalWalletBalance <= command.Amount)
            {
                ModelState.AddModelError("Amount", $"موجودی شما (که {personalWalletBalance} تومان میباشد) کافی نیست");
                ViewData["personalWalletId"] = command.PersonalWalletId;
                return View(command);
            }

            _personalWalletOperationApplication.TransferToAnotherWallet(command);
            return View("CashTransferVerify", command);
        }

        public IActionResult CashTransferVerify()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CashTransferVerify(TransferToAnotherWallet command)
        {
            //to check if verify code is true then...
            var result = _personalWalletOperationApplication.CheckDynamicCode(command.VerifyCode);
            if (!result.IsSuccedded)
            {
                ModelState.AddModelError("VerifyCode", result.Message);
                return View(command);
            }

            _personalWalletApplication.ChangeBalanceOfSenderAndReceiver(command);
            UserController.transferResult = result.Message;
            return RedirectToAction("wallet");
        }
        #endregion

        #region WithdrawOperation
        public IActionResult CashWithdraw(long id)
        {
            ViewData["personalWalletId"] = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult CashWithdraw(WithdrawPersonalWallet command)
        {
            var personalWalletBalance = _personalWalletApplication.GetBalanceByPersonalWalletId(command.PersonalWalletId);
            if (personalWalletBalance <= command.Amount)
            {
                ModelState.AddModelError("Amount", $"موجودی شما (که {personalWalletBalance} تومان میباشد) کافی نیست");
                return View(command);
            }
            var result = _personalWalletOperationApplication.WithdrawPersonalWallet(command);
            UserController.withdrawResult = result.Message;
            return RedirectToAction("Wallet");
        }
        #endregion

        #region CreateSellerPanel

        public IActionResult CreateSellerPanel()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult CreateSellerPanel(CreateSellerPanel command)
        {
            command.UserId = _authHelper.CurrentAccountInfo().Id;
            var result = _sellerPanelApplication.Create(command);
            UserController.message = result.Message;
            return RedirectToAction("UserProfile");
        }
        #endregion

        #region UserOrderManageMent
        public IActionResult Orders()
        {
            var userId=_authHelper.CurrentAccountInfo().Id;

            var currentOrder = _orderApplication.GetUserCurrentOrdersByUserId(userId);
            var recievedOrder = _orderApplication.GetUserRecievedOrdersByUserId(userId);
            var canceledOrder=_orderApplication.GetUserCanceledOrdersByUserId(userId);
            var model=new Tuple<List<OrderViewModel>, List<OrderViewModel>, List<OrderViewModel>>(currentOrder, recievedOrder, canceledOrder);  
            return View(model);
        }

        public IActionResult ShowOrderItems(long id)
        {
            //id==Order Id Passed

            var orderItems=_orderItemApplication.GetListByOrderId(id);
            return PartialView(orderItems);
        }
        #endregion

    }

    public class Chart
    {
        public string Label { get; set; }
        public List<long> Data { get; set; }
        public string BackgroudColor { get; set; }
        public string BorderColor { get; set; }
    }
}
