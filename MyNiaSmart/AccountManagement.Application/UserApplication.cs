using _0_Framework;
using _0_Framework.Contract;
using _0_Framework.Utilities;
using _01_Framework.Application;
using AccountManagement.Application.Contract.User;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.UserPersonalityAgg;
using AccountManagement.Domain.WalletAgg.BusinessWalletAgg;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletChartAgg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AccountManagement.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IUserPersonalityRepository _userPersonalityRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IPersonalWalletRepository _personalWalletRepository;
        private readonly IBusinessWalletRepository _businessWalletRepository;
        private readonly IPersonalWalletChartRepository _personalWalletChartRepository;

        public UserApplication(IUserRepository userRepository, IFileUploader fileUploader,
            IUserPersonalityRepository userPersonalityRepository, IAuthHelper authHelper,
            IPersonalWalletRepository personalWalletRepository,
            IBusinessWalletRepository businessWalletRepository,
            IPersonalWalletChartRepository personalWalletChartRepository)
        {
            _userRepository = userRepository;
            _fileUploader = fileUploader;
            _userPersonalityRepository = userPersonalityRepository;
            _authHelper = authHelper;
            _personalWalletRepository = personalWalletRepository;
            _businessWalletRepository = businessWalletRepository;
            _personalWalletChartRepository = personalWalletChartRepository;
        }
        public OperationResult Create(CreateUser command)
        {
            var operation = new OperationResult();
            if (_userRepository.IsExist(x => x.MobileNumber == command.MobileNumber))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var birthday = DateTime.MinValue;
            if (command.Birthday != null)
                birthday = command.Birthday.ToGeorgianDateTime();

            var picturePath = _fileUploader.Upload(command.ProfilePhoto, "UserPhoto");
            var user = new User(command.FullName, command.MobileNumber
                , command.Capital, command.City, command.Address, command.NationalCode
                , birthday, picturePath, command.IntroductorFullname, command.IntroductorMobileNumber, command.Experience);
            _userRepository.Create(user);
            _userRepository.Savechange();

            //TO set new user as a client, we add a record in userPersonalityTable for this user
            var userPersonality = new UserPersonality(user.Id, PersonalityTitle.Client);
            _userPersonalityRepository.Create(userPersonality);
            _userPersonalityRepository.Savechange();

            return operation.Succedded();

        }

        public OperationResult Edit(EditUser command)
        {
            var operation = new OperationResult();
            var user = _userRepository.GetById(command.Id);
            if (user == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_userRepository.IsExist(x => x.MobileNumber == command.MobileNumber && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var birthday = DateTime.MinValue;
            if (command.Birthday != null)
                birthday = command.Birthday.ToGeorgianDateTime();

            if (command.ProfilePhoto != null)
               _fileUploader.RemovePicture(user.ProfilePhoto);

            var picturePath = _fileUploader.Upload(command.ProfilePhoto, "UserPhoto");

            user.Edit(command.FullName, command.MobileNumber
                , command.Capital, command.City, command.Address, command.NationalCode
                , birthday, picturePath, command.IntroductorFullname, command.IntroductorMobileNumber, command.Grade, command.Experience);
            _userRepository.Savechange();
            return operation.Succedded();
        }
        public OperationResult RegisterOrLogin(RegisterOrLoginUser command)
        {
            var operation = new OperationResult();
            var account = _userRepository.GetUserByMobileNumber(command.MobileNumber);
            //اگر کاربر جدید و نام کاربری را وارد نکرده
            if (account == null && command.FullName == null)
                return operation.Failed("شما به عنوان کاربر جدید،باید نام و نام خانوادگی هم پر کنید");

            // اگر شماره همراه ثبت و با نام جدید لاگین شود
            if(account!=null)
            {
                if (command.FullName != null && account.FullName != command.FullName)
                    return operation.Failed("شماره همراه با نام کاربری متابقت ندارد");
            }

            //اگر کاربر جدید است و میخواهد ثبت نام کند 
            if (account == null && command.FullName != null)
            {
                account = new User(command.FullName, command.MobileNumber);
                _userRepository.Create(account);
                _userRepository.Savechange();
                account.GenerateActiveCode(GenerateUniqueCode.GenerateRandomNo());
                var value = account.ActiveCode;

                #region ToDo Sending Sms With Verification Code then we will change active code
                string[] p = { "ActiveCode" };
                string[] v = { value };

                string pValue = "";
                string vValue = "";
                for (int i = 0; i < p.Length; i++)
                {
                    pValue = pValue + "p" + (i + 1) + "=" + p[i] + "&";
                    vValue = vValue + "v" + (i + 1) + "=" + v[i] + "&";
                }
                SendPattern.SendSms("rhnx93pt0h2iw2x", command.MobileNumber, pValue, vValue);
                #endregion

                _userRepository.Savechange();

                #region Creating personal and business Wallet for new user
                var stringDate = DateTime.Now.ToFarsi().ToArray().ToList();
                var first = stringDate[1].ToString() + stringDate[2].ToString() + stringDate[3].ToString();
                var walletNumber = account.MobileNumber.Substring(1);
                var PersonalcardNumber = first + "1" + "98" + walletNumber;
                var owneregistrationDate = stringDate[2].ToString() + stringDate[3].ToString() + stringDate[4].ToString() + stringDate[5].ToString() + stringDate[6].ToString();
                var personalWallet = new PersonalWallet(PersonalcardNumber, account.FullName, owneregistrationDate,account.Grade, account.Id);

                //personalWallet.SaveBalanceUpdateDate(DateTime.Now);
                if (_personalWalletRepository.IsExist(x => x.UserId == account.Id))
                    return operation.Failed(ApplicationMessage.DuplicatedRecord);

                _personalWalletRepository.Create(personalWallet);
                _personalWalletRepository.Savechange();

                var personalWalletChart = new PersonalWalletChart(account.Grade, DateTime.Now, personalWallet.Id);
                _personalWalletChartRepository.Create(personalWalletChart);
                _personalWalletChartRepository.Savechange();

                //creating businessWallet
                var businessCardNumber= first + "2" + "98" + walletNumber;
                var businessWallet =new BusinessWallet(businessCardNumber, account.FullName, owneregistrationDate,account.Grade, account.Id);
                if (_businessWalletRepository.IsExist(x => x.UserId == account.Id))
                    return operation.Failed(ApplicationMessage.DuplicatedRecord);

                _businessWalletRepository.Create(businessWallet);
                _businessWalletRepository.Savechange();
                #endregion

                return operation.Succedded();
            }

            //اگر شماره همراه ثبت و کاربر میخواهد لاگین شود
            account.GenerateActiveCode(GenerateUniqueCode.GenerateRandomNo());
            var newvalue = account.ActiveCode;
            string[] pp = { "ActiveCode" };
            string[] vv = { newvalue };

            string ppValue = "";
            string vvValue = "";
            for (int i = 0; i < pp.Length; i++)
            {
                ppValue = ppValue + "p" + (i + 1) + "=" + pp[i] + "&";
                vvValue = vvValue + "v" + (i + 1) + "=" + vv[i] + "&";
            }

            SendPattern.SendSms("rhnx93pt0h2iw2x", account.MobileNumber, ppValue, vvValue);
            _userRepository.Savechange();
            return operation.Succedded();

        }
        public OperationResult CheckVerificationCode(VerificationCode command)
        {
            var operation = new OperationResult();
            var account = _userRepository.GetUserByActiveCode(command.Code);
            if (account==null)
                return operation.Failed("کد وارد شده معتبر نیست");

            //حالتی که شانسی یه کد وارد کنه ولی اتفاقی مال یه نفز دیگه باشه. احتمال یک به )
            if(account!=null && account.ActiveCode!=command.Code)
                return operation.Failed("کد وارد شده معتبر نیست");


            //ToChangeAccountInformation
            account.ActiveUser();
            account.GenerateActiveCode(GenerateUniqueCode.GenerateRandomNo());
            _userRepository.Savechange();

            //Login Operation
            var authViewModel = new AuthViewModel(account.Id, account.FullName, account.MobileNumber);
            _authHelper.Signin(authViewModel);
            return operation.Succedded();
        }

        public EditUser GetDetails(long id)
        {
            return _userRepository.GetDetails(id);
        }

        public List<UserViewModel> GetList()
        {
            return _userRepository.GetList();
        }

        public void LogOut()
        {
            _authHelper.SignOut();

        }

        public bool IsUserAdmin(long userId)
        {
           return _userRepository.IsUserAdmin(userId);
        }
    }
}
