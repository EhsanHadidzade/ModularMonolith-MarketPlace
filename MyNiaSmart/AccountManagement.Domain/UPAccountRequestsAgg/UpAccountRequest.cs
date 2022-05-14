using _0_Framework.Domain;
using AccountManagement.Domain.UpAccountRequestRejectionReasonAgg;
using AccountManagement.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UPAccountRequestsAgg
{
    public class UpAccountRequest : BaseEntity
    {
        //personalInformation
        public string PI_FUllName { get; private set; }
        public string PI_FatherName { get; private set; }
        public string PI_IdentityNumber { get; private set; }
        public string PI_NationalCode { get; private set; }
        public string Capital { get; private set; }
        public string City { get; private set; }
        public DateTime PI_BirthdayDate { get; private set; }
        public DateTime PI_RegistrationDate { get; private set; }
        public bool PI_IsMale { get; private set; }

        //PersonalDocument
        public bool PI_IsNewIdentity { get; private set; }
        public bool PI_IsNewNationalCard { get; private set; }
        public string PD_IdentityCard { get; private set; }
        public string PD_NationalCardFrontSide { get; private set; }
        public string PD_NationalCardBackSide { get; private set; }
        public string PD_NationalCodeTrackingPaper { get; private set; }

        //BankInformation
        public string BI_BankName { get; private set; }
        public string BI_BankAccountNumber { get; private set; }
        public string BI_CreditCardNumber { get; private set; }
        public string BI_ShabaNumber { get; private set; }

        //BankDocument
        public bool BI_IsCreditCardWithFullInfo { get; private set; }
        public string BD_CreditCardFrontSide { get; private set; }
        public string BD_CreditCardBackSide { get; private set; }
        public string BD_ShabaPrint { get; private set; }

        //GuarantyInformation
        public bool GI_IsChequeGuarantyType { get; private set; }
        public string GI_ChequeNumber { get; private set; }
        public string GI_SafteNumber { get; private set; }
        public string GI_ChequeBankBranch { get; private set; }
        public string GI_ShenaseSayadiCheque { get; private set; }

        //GuarantyDocument
        public string GD_ChequeFrontSide { get; private set; }
        public string GD_ChequeBackSide { get; private set; }
        public string GD_SafteFrontSide { get; private set; }
        public string GD_SafteBackSide { get; private set; }

        //toCheck If Request is Confirmed By Administrator
        public bool IsRequestConfirmedByAdmin { get; private set; }

        //toCheck If Request is Confirmed By Client
        public bool IsRequestConfirmedByClient { get; private set; }

        //To Report the reason that why a request is still not confirmed By Admin
        public string RejectionReason { get; private set; }


        #region Relation
        public long UserId { get; private set; }
        public User User { get; set; }
        public List<UpAccountRequestRejectionReason> UpAccountRequestRejectionReasons { get; set; }
        #endregion

        public UpAccountRequest(string pI_FUllName, string pI_FatherName, string pI_IdentityNumber,
            string pI_NationalCode, string capital, string city, DateTime pI_BirthdayDate, DateTime pI_RegistrationDate,
            bool pI_IsMale, bool pI_IsNewIdentity, bool pI_IsNewNationalCard, string pD_IdentityCard,
            string pD_NationalCardFrontSide, string pD_NationalCardBackSide, string pD_NationalCodeTrackingPaper,
            string bI_BankName, string bI_BankAccountNumber, string bI_CreditCardNumber, string bI_ShabaNumber,
            bool bI_IsCreditCardWithFullInfo, string bD_CreditCardFrontSide, string bD_CreditCardBackSide,
            string bD_ShabaPrint, bool gI_IsChequeGuarantyType, string gI_ChequeNumber, string gI_SafteNumber,
            string gI_ChequeBankBranch, string gI_ShenaseSayadiCheque, string gD_ChequeFrontSide, string gD_ChequeBackSide,
            string gD_SafteFrontSide, string gD_SafteBackSide, long userId)
        {
            PI_FUllName = pI_FUllName;
            PI_FatherName = pI_FatherName;
            PI_IdentityNumber = pI_IdentityNumber;
            PI_NationalCode = pI_NationalCode;
            Capital = capital;
            City = city;
            PI_BirthdayDate = pI_BirthdayDate;
            PI_RegistrationDate = pI_RegistrationDate;
            PI_IsMale = pI_IsMale;
            PI_IsNewIdentity = pI_IsNewIdentity;
            PI_IsNewNationalCard = pI_IsNewNationalCard;
            PD_IdentityCard = pD_IdentityCard;
            PD_NationalCardFrontSide = pD_NationalCardFrontSide;
            PD_NationalCardBackSide = pD_NationalCardBackSide;
            PD_NationalCodeTrackingPaper = pD_NationalCodeTrackingPaper;
            BI_BankName = bI_BankName;
            BI_BankAccountNumber = bI_BankAccountNumber;
            BI_CreditCardNumber = bI_CreditCardNumber;
            BI_ShabaNumber = bI_ShabaNumber;
            BI_IsCreditCardWithFullInfo = bI_IsCreditCardWithFullInfo;
            BD_CreditCardFrontSide = bD_CreditCardFrontSide;
            BD_CreditCardBackSide = bD_CreditCardBackSide;
            BD_ShabaPrint = bD_ShabaPrint;
            GI_IsChequeGuarantyType = gI_IsChequeGuarantyType;
            GI_ChequeNumber = gI_ChequeNumber;
            GI_SafteNumber = gI_SafteNumber;
            GI_ChequeBankBranch = gI_ChequeBankBranch;
            GI_ShenaseSayadiCheque = gI_ShenaseSayadiCheque;
            GD_ChequeFrontSide = gD_ChequeFrontSide;
            GD_ChequeBackSide = gD_ChequeBackSide;
            GD_SafteFrontSide = gD_SafteFrontSide;
            GD_SafteBackSide = gD_SafteBackSide;
            UserId = userId;

            IsRequestConfirmedByAdmin = false;
            IsRequestConfirmedByClient = true;
        }

        public void Edit(string pI_FUllName, string pI_FatherName, string pI_IdentityNumber,
            string pI_NationalCode, string capital, string city, DateTime pI_BirthdayDate, DateTime pI_RegistrationDate,
            bool pI_IsMale, bool pI_IsNewIdentity, bool pI_IsNewNationalCard, string pD_IdentityCard,
            string pD_NationalCardFrontSide, string pD_NationalCardBackSide, string pD_NationalCodeTrackingPaper,
            string bI_BankName, string bI_BankAccountNumber, string bI_CreditCardNumber, string bI_ShabaNumber,
            bool bI_IsCreditCardWithFullInfo, string bD_CreditCardFrontSide, string bD_CreditCardBackSide,
            string bD_ShabaPrint, bool gI_IsChequeGuarantyType, string gI_ChequeNumber, string gI_SafteNumber,
            string gI_ChequeBankBranch, string gI_ShenaseSayadiCheque, string gD_ChequeFrontSide, string gD_ChequeBackSide,
            string gD_SafteFrontSide, string gD_SafteBackSide, long userId)
        {
            PI_FUllName = pI_FUllName;
            PI_FatherName = pI_FatherName;
            PI_IdentityNumber = pI_IdentityNumber;
            PI_NationalCode = pI_NationalCode;
            Capital = capital;
            City = city;
            PI_BirthdayDate = pI_BirthdayDate;
            PI_RegistrationDate = pI_RegistrationDate;
            PI_IsMale = pI_IsMale;
            PI_IsNewIdentity = pI_IsNewIdentity;
            PI_IsNewNationalCard = pI_IsNewNationalCard;
            if (!string.IsNullOrWhiteSpace(pD_IdentityCard))
            {
                PD_IdentityCard = pD_IdentityCard;
            }
            if (!string.IsNullOrWhiteSpace(pD_NationalCardFrontSide))
            {
                PD_NationalCardFrontSide = pD_NationalCardFrontSide;
            }
            if (!string.IsNullOrWhiteSpace(pD_NationalCardBackSide))
            {
                PD_NationalCardBackSide = pD_NationalCardBackSide;
            }
            if (!string.IsNullOrWhiteSpace(pD_NationalCodeTrackingPaper))
            {
                PD_NationalCodeTrackingPaper = pD_NationalCodeTrackingPaper;
            }
            BI_BankName = bI_BankName;
            BI_BankAccountNumber = bI_BankAccountNumber;
            BI_CreditCardNumber = bI_CreditCardNumber;
            BI_ShabaNumber = bI_ShabaNumber;
            BI_IsCreditCardWithFullInfo = bI_IsCreditCardWithFullInfo;

            if (!string.IsNullOrWhiteSpace(bD_CreditCardFrontSide))
            {
                BD_CreditCardFrontSide = bD_CreditCardFrontSide;
            }
            if (!string.IsNullOrWhiteSpace(bD_CreditCardBackSide))
            {
                BD_CreditCardBackSide = bD_CreditCardBackSide;
            }
            if (!string.IsNullOrWhiteSpace(bD_ShabaPrint))
            {
                BD_ShabaPrint = bD_ShabaPrint;
            }
            GI_IsChequeGuarantyType = gI_IsChequeGuarantyType;
            GI_ChequeNumber = gI_ChequeNumber;
            GI_SafteNumber = gI_SafteNumber;
            GI_ChequeBankBranch = gI_ChequeBankBranch;
            GI_ShenaseSayadiCheque = gI_ShenaseSayadiCheque;

            if (!string.IsNullOrWhiteSpace(gD_ChequeFrontSide))
            {
                GD_ChequeFrontSide = gD_ChequeFrontSide;
            }
            if (!string.IsNullOrWhiteSpace(gD_ChequeBackSide))
            {
                GD_ChequeBackSide = gD_ChequeBackSide;
            }
            if (!string.IsNullOrWhiteSpace(gD_SafteFrontSide))
            {
                GD_SafteFrontSide = gD_SafteFrontSide;
            }
            if (!string.IsNullOrWhiteSpace(gD_SafteBackSide))
            {
                GD_SafteBackSide = gD_SafteBackSide;
            }

            UserId = userId;

            IsRequestConfirmedByAdmin = false;
            IsRequestConfirmedByClient = true;
        }
        public void ConfirmRequestWithAdmin()
        {
            IsRequestConfirmedByAdmin = true;
        }
        public void ConfirmRequestWithClient()
        {
            IsRequestConfirmedByClient = true;
        }
        public void RejectRequestWithClient()
        {
            IsRequestConfirmedByClient = false;
        }

    }
}
