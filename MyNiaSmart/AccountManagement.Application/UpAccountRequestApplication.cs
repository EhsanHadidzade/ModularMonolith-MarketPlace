using _0_Framework.Contract;
using _0_Framework.Utilities;
using _01_Framework.Application;
using AccountManagement.Application.Contract.RejectionReason;
using AccountManagement.Application.Contract.UpAccountRequest;
using AccountManagement.Application.Contract.UpAccountRequestRejectionReason;
using AccountManagement.Domain.UpAccountRequestRejectionReasonAgg;
using AccountManagement.Domain.UPAccountRequestsAgg;
using System;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class UpAccountRequestApplication : IUPAccountRequestApplication
    {
        private readonly IUPAccountRequestRepository _uPAccountRequestRepository;
        private readonly IUpAccountRequestRejectionReasonRepository _upAccountRequestRejectionReasonRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;
        private readonly IRejectionReasonApplication _rejectionReasonApplication;
        private readonly IUpAccountRequestRejectionReasonApplication _upAccountRequestRejectionReasonApplication;

        public UpAccountRequestApplication(IUPAccountRequestRepository uPAccountRequestRepository,
            IFileUploader fileUploader, IAuthHelper authHelper, IRejectionReasonApplication rejectionReasonApplication,
            IUpAccountRequestRejectionReasonApplication upAccountRequestRejectionReasonApplication, 
            IUpAccountRequestRejectionReasonRepository upAccountRequestRejectionReasonRepository)
        {
            _uPAccountRequestRepository = uPAccountRequestRepository;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _rejectionReasonApplication = rejectionReasonApplication;
            _upAccountRequestRejectionReasonApplication = upAccountRequestRejectionReasonApplication;
            _upAccountRequestRejectionReasonRepository = upAccountRequestRejectionReasonRepository;
        }

        public void ConfirmUpAccountRequestByAdmin(long id)
        {
            var request = _uPAccountRequestRepository.GetById(id);
            request.ConfirmRequestWithAdmin();
            request.RejectRequestWithClient();
             
            _upAccountRequestRejectionReasonRepository.RemoveUpAccountRequestRejectionReasonsofOneRequestByRequestId(id);

            _uPAccountRequestRepository.Savechange();
        }

        public OperationResult Create(CreateUpAccountRequest command)
        {
            var operation = new OperationResult();
            var user = _authHelper.CurrentAccountInfo();
            if (_uPAccountRequestRepository.IsExist(x => x.UserId == user.Id))
            {
                return operation.Failed("امکان درخواست دوباره برای شما وجود ندارد");
            }

            var birthDayDate = command.PI_BirthdayDate.ToGeorgianDateTime();
            var registrationDate = command.PI_RegistrationDate.ToGeorgianDateTime();
            //upload PersonalDocument
            string PD_IdentityCard = _fileUploader.UploadDocument(command.UploadPD_IdentityCard, "شناسنامه", $"UpAccountDocument//{user.Fullname}");
            string PD_NationalCardFrontSide = _fileUploader.UploadDocument(command.UploadPD_NationalCardFrontSide, "روی کارت ملی", $"UpAccountDocument//{user.Fullname}");
            string PD_NationalCardBackSide = _fileUploader.UploadDocument(command.UploadPD_NationalCardBackSide, "پشت کارت ملی", $"UpAccountDocument//{user.Fullname}");
            string PD_NationalCardTrackingPaper = _fileUploader.UploadDocument(command.UploadPD_NationalCodeTrackingPaper, " رسید رهگیری کارت ملی قدیم", $"UpAccountDocument//{user.Fullname}");
            //UploadBankDocument
            string BD_CreditCardFrontSide = _fileUploader.UploadDocument(command.UploadBD_CreditCardFrontSide, "روی کارت عابر بانک", $"UpAccountDocument//{user.Fullname}");
            string BD_CreditCardBackSide = _fileUploader.UploadDocument(command.UploadBD_CreditCardBackSide, "پشت کارت عابر بانک", $"UpAccountDocument//{user.Fullname}");
            string BD_ShabaPrint = _fileUploader.UploadDocument(command.UploadBD_ShabaPrint, "پرینت شبا", $"UpAccountDocument//{user.Fullname}");
            //UploadGuarantyDocument
            string GD_ChequeFrontSide = _fileUploader.UploadDocument(command.UploadGD_ChequeFrontSide, "روی چک", $"UpAccountDocument//{user.Fullname}");
            string GD_ChequeBackSide = _fileUploader.UploadDocument(command.UploadGD_ChequeBackSide, "پشت چک", $"UpAccountDocument//{user.Fullname}");
            string GD_SafteFrontSide = _fileUploader.UploadDocument(command.UploadGD_SafteFrontSide, "روی سفته", $"UpAccountDocument//{user.Fullname}");
            string GD_SafteBackSide = _fileUploader.UploadDocument(command.UploadGD_SafteBackSide, "پشت سفته", $"UpAccountDocument//{user.Fullname}");

            var upaccountrequest = new UpAccountRequest(command.PI_FUllName, command.PI_FatherName, command.PI_IdentityNumber,
                command.PI_NationalCode, command.PI_Capital, command.PI_City, birthDayDate, registrationDate, command.PI_IsMale,
                command.PI_IsNewIdentity, command.PI_IsNewNationalCard, PD_IdentityCard,
                PD_NationalCardFrontSide, PD_NationalCardBackSide, PD_NationalCardTrackingPaper,
                command.BI_BankName, command.BI_BankAccountNumber, command.BI_CreditCardNumber,
                command.BI_ShabaNumber, command.BI_IsCreditCardWithFullInfo, BD_CreditCardFrontSide,
                BD_CreditCardBackSide, BD_ShabaPrint, command.GI_IsChequeGuarantyType, command.GI_ChequeNumber,
                command.GI_SafteNumber, command.GI_ChequeBankBranch, command.GI_ShenaseSayadiCheque,
                GD_ChequeFrontSide, GD_ChequeBackSide, GD_SafteFrontSide, GD_SafteBackSide, user.Id
                );
            _uPAccountRequestRepository.Create(upaccountrequest);
            _uPAccountRequestRepository.Savechange();
            return operation.Succedded("درخواست ارتقا حساب کاربری شما با موفقیت ثبت ودر حال بررسی میباشد");
        }

        public OperationResult Edit(EditUpAccountRequest command)
        {
            var operation = new OperationResult();
            var user = _authHelper.CurrentAccountInfo();
            var upAccountRequest = _uPAccountRequestRepository.GetById(command.Id);
            var birthDayDate = command.PI_BirthdayDate.ToGeorgianDateTime();
            var registrationDate = command.PI_RegistrationDate.ToGeorgianDateTime();

            //upload PersonalDocument
            #region To remove old document from static files for personal document
            if (command.UploadPD_IdentityCard != null)
                _fileUploader.RemovePicture(upAccountRequest.PD_IdentityCard);

            if (command.UploadPD_NationalCardFrontSide != null)
                _fileUploader.RemovePicture(upAccountRequest.PD_NationalCardFrontSide);

            if (command.UploadPD_NationalCardBackSide != null)
                _fileUploader.RemovePicture(upAccountRequest.PD_NationalCardBackSide);

            if (command.UploadPD_NationalCodeTrackingPaper != null)
                _fileUploader.RemovePicture(upAccountRequest.PD_NationalCodeTrackingPaper);
            #endregion
            string PD_IdentityCard = _fileUploader.UploadDocument(command.UploadPD_IdentityCard, "شناسنامه", $"UpAccountDocument//{user.Fullname}");
            string PD_NationalCardFrontSide = _fileUploader.UploadDocument(command.UploadPD_NationalCardFrontSide, "روی کارت ملی", $"UpAccountDocument//{user.Fullname}");
            string PD_NationalCardBackSide = _fileUploader.UploadDocument(command.UploadPD_NationalCardBackSide, "پشت کارت ملی", $"UpAccountDocument//{user.Fullname}");
            string PD_NationalCardTrackingPaper = _fileUploader.UploadDocument(command.UploadPD_NationalCodeTrackingPaper, " رسید رهگیری کارت ملی قدیم", $"UpAccountDocument//{user.Fullname}");

            //UploadBankDocument
            #region To remove old document from static files for bank document
            if (command.UploadBD_CreditCardFrontSide != null)
                _fileUploader.RemovePicture(upAccountRequest.BD_CreditCardFrontSide);

            if (command.UploadBD_CreditCardBackSide != null)
                _fileUploader.RemovePicture(upAccountRequest.BD_CreditCardBackSide);

            if (command.UploadBD_ShabaPrint != null)
                _fileUploader.RemovePicture(upAccountRequest.BD_ShabaPrint);

            #endregion
            string BD_CreditCardFrontSide = _fileUploader.UploadDocument(command.UploadBD_CreditCardFrontSide, "روی کارت عابر بانک", $"UpAccountDocument//{user.Fullname}");
            string BD_CreditCardBackSide = _fileUploader.UploadDocument(command.UploadBD_CreditCardBackSide, "پشت کارت عابر بانک", $"UpAccountDocument//{user.Fullname}");
            string BD_ShabaPrint = _fileUploader.UploadDocument(command.UploadBD_ShabaPrint, "پرینت شبا", $"UpAccountDocument//{user.Fullname}");

            //UploadGuarantyDocument
            #region To remove old document from static files for guaranty document
            if (command.UploadGD_ChequeFrontSide != null)
                _fileUploader.RemovePicture(upAccountRequest.GD_ChequeFrontSide);

            if (command.UploadGD_ChequeBackSide != null)
                _fileUploader.RemovePicture(upAccountRequest.GD_ChequeBackSide);

            if (command.UploadGD_SafteFrontSide != null)
                _fileUploader.RemovePicture(upAccountRequest.GD_SafteFrontSide);

            if (command.UploadGD_SafteBackSide != null)
                _fileUploader.RemovePicture(upAccountRequest.GD_SafteBackSide);

            #endregion
            string GD_ChequeFrontSide = _fileUploader.UploadDocument(command.UploadGD_ChequeFrontSide, "روی چک", $"UpAccountDocument//{user.Fullname}");
            string GD_ChequeBackSide = _fileUploader.UploadDocument(command.UploadGD_ChequeBackSide, "پشت چک", $"UpAccountDocument//{user.Fullname}");
            string GD_SafteFrontSide = _fileUploader.UploadDocument(command.UploadGD_SafteFrontSide, "روی سفته", $"UpAccountDocument//{user.Fullname}");
            string GD_SafteBackSide = _fileUploader.UploadDocument(command.UploadGD_SafteBackSide, "پشت سفته", $"UpAccountDocument//{user.Fullname}");

            upAccountRequest.Edit(command.PI_FUllName, command.PI_FatherName, command.PI_IdentityNumber,
                command.PI_NationalCode, command.PI_Capital, command.PI_City, birthDayDate, registrationDate, command.PI_IsMale,
                command.PI_IsNewIdentity, command.PI_IsNewNationalCard, PD_IdentityCard,
                PD_NationalCardFrontSide, PD_NationalCardBackSide, PD_NationalCardTrackingPaper,
                command.BI_BankName, command.BI_BankAccountNumber, command.BI_CreditCardNumber,
                command.BI_ShabaNumber, command.BI_IsCreditCardWithFullInfo, BD_CreditCardFrontSide,
                BD_CreditCardBackSide, BD_ShabaPrint, command.GI_IsChequeGuarantyType, command.GI_ChequeNumber,
                command.GI_SafteNumber, command.GI_ChequeBankBranch, command.GI_ShenaseSayadiCheque,
                GD_ChequeFrontSide, GD_ChequeBackSide, GD_SafteFrontSide, GD_SafteBackSide, user.Id
                );
            _uPAccountRequestRepository.Savechange();
            return operation.Succedded();

        }

        public Tuple<List<RejectionReasonViewModel>, List<long>, long> GetAllReasonesWithSelectedReasonsOfOneRequestByRequestId(long requestId)
        {
            var reasons = _rejectionReasonApplication.GetList();
            var selectedReasons = _upAccountRequestRejectionReasonApplication.GetAllRejectionReasonIdsOfOneUpAccountRequest(requestId);
            return Tuple.Create<List<RejectionReasonViewModel>, List<long>, long>(reasons, selectedReasons, requestId);
        }


        public List<UpAccountRequestViewModel> GetList()
        {
            return _uPAccountRequestRepository.GetList();
        }

        public EditUpAccountRequest GetDetails(long id)
        {
            return _uPAccountRequestRepository.GetDetails(id);
        }

        public bool HasUserRequestedForUpAccount(long userId)
        {
            return _uPAccountRequestRepository.HasUserRequestedForUpAccount(userId);
        }

        public bool IsUpAccountRequestConfirmedWithAdminByUserId(long userId)
        {
            return _uPAccountRequestRepository.IsUpAccountRequestConfirmedByAdmin(userId);
        }

        public void DeactiveClientConfirmation(long requestId)
        {
            _uPAccountRequestRepository.DeactiveClientConfirmation(requestId);
        }

        public UpAccountRequestViewModel GetByUserId(long userId)
        {
            return _uPAccountRequestRepository.GetByUserId(userId);
        }
    }
}
