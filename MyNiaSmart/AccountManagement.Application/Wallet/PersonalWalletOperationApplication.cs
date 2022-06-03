using _0_Framework.Contract;
using _0_Framework.Utilities;
using _0_Framework.Utilities.ZarinPal;
using AccountManagement.Application.Contract.PersonalWallet;
using AccountManagement.Application.Contract.PersonalWalletOperation;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Wallet
{
    public class PersonalWalletOperationApplication : IPersonalWalletOperationApplication
    {
        private readonly IPersonalWalletOperationRepository _personalWalletOperationRepository;
        private readonly IPersonalWalletRepository _personalWalletRepository;
        private readonly IPersonalWalletApplication _personalWalletApplication;
        private readonly IAuthHelper _authHelper;

        public PersonalWalletOperationApplication(IPersonalWalletOperationRepository personalWalletOperationRepository,
            IAuthHelper authHelper, IPersonalWalletApplication personalWalletApplication, IPersonalWalletRepository personalWalletRepository)
        {
            _personalWalletOperationRepository = personalWalletOperationRepository;
            _authHelper = authHelper;
            _personalWalletApplication = personalWalletApplication;
            _personalWalletRepository = personalWalletRepository;
        }



        public long ChargePersonalWallet(ChargePersonalWallet command)
        {
            var walletOperation = new Personalwalletoperation(command.Amount, false, PersonalWalletOperationTitle.Deposite,
                command.PersonalWalletId, command.WalletOperationTypeId);
            walletOperation.SetDepositeType(PersonalWalletDepositeType.OnlineGatewayPayment);
            _personalWalletOperationRepository.Create(walletOperation);
            _personalWalletOperationRepository.Savechange();
            return walletOperation.Id;
        }

        public OperationResult WithdrawPersonalWallet(WithdrawPersonalWallet command)
        {
            var operation = new OperationResult();
            var walletOperation = new Personalwalletoperation(command.Amount, false, PersonalWalletOperationTitle.Withdraw,
                command.PersonalWalletId, command.WalletOperationTypeId);
            walletOperation.SetWithdrawStatus(PersonalWalletWithdrawStatus.Processing);
            _personalWalletOperationRepository.Create(walletOperation);
            _personalWalletOperationRepository.Savechange();
            return operation.Succedded("درخواست برداشت وجه از کیف پول شخصی شما با موفقیت انجام شد و در حال بررسی میباشد");
        }
        public OperationResult CheckDynamicCode(string verifyCode)
        {
            var operation = new OperationResult();
            var personalWalletOperation = _personalWalletOperationRepository.GetByVerifyCode(verifyCode);
            if (personalWalletOperation == null)
                return operation.Failed("رمز را شتباه وارد میکنید");


            personalWalletOperation.GenerateVerifyCode(GenerateUniqueCode.GenerateRandomNo());
            personalWalletOperation.PaymentIsSuccessful();

            _personalWalletOperationRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult TransferToAnotherWallet(TransferToAnotherWallet command)
        {
            var operation = new OperationResult();
            var userMobile = _authHelper.CurrentAccountInfo().Mobile;
            var destinationPersonalwallet = _personalWalletRepository.GetByCardNumber(command.DestinationCardNumber);

            var walletOperation = new Personalwalletoperation(command.Amount, false, PersonalWalletOperationTitle.Transfer,
                command.PersonalWalletId, command.WalletOperationTypeId);
            walletOperation.GenerateVerifyCode(GenerateUniqueCode.GenerateRandomNo());
            var receiverFullName = _personalWalletRepository.GetFullNameByCardNumber(command.DestinationCardNumber);
            walletOperation.SetReceiverFullName(receiverFullName);
            _personalWalletOperationRepository.Create(walletOperation);
            _personalWalletOperationRepository.Savechange();

            #region ToDo Sending Sms With Verification Code then we will change active code
            string[] p = { "paymentamount", "type", "personreciver", "fulldateandtime", "dynamiccode" };
            string[] v = { $"{ command.Amount.ToString()} تومان", "کارت شخصی",receiverFullName, DateTime.Now.ToFarsiFull(), walletOperation.VerifyCode };

            string pValue = "";
            string vValue = "";
            for (int i = 0; i < p.Length; i++)
            {
                pValue = pValue + "p" + (i + 1) + "=" + p[i] + "&";
                vValue = vValue + "v" + (i + 1) + "=" + v[i] + "&";
            }
            SendPattern.SendSms("bc6y94aigjbsz0y", userMobile, pValue, vValue);
            #endregion

            return operation.Succedded();

        }

        public List<PersonalWalletOperationViewModel> GetWithdrawRequests()
        {
            return _personalWalletOperationRepository.GetWithdrawRequests();
        }

        public void SetWithdrawRequestStatus(SetPersonalWalletOperationWithdrawRequestStatus command)
        {
            var personalWalletOperation = _personalWalletOperationRepository.GetById(command.PersonalWalletOperationId);
            personalWalletOperation.SetWithdrawStatus(command.WithdrawRequestStatus);

            if (command.WithdrawRequestStatus == PersonalWalletWithdrawStatus.IsConfirmed)
                personalWalletOperation.PaymentIsSuccessful();

            _personalWalletOperationRepository.Savechange();
        }

        public List<PersonalWalletOperationViewModel> GetAllOperationsByWalletId(long personalWalletId)
        {
            return _personalWalletOperationRepository.GetAllOperationsByWalletId(personalWalletId);
        }
    }
}
