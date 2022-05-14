using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UpAccountRequest
{
    public class CreateUpAccountRequest
    {
        //personalInformation
        public string PI_FUllName { get; set; }
        public string PI_FatherName { get; set; }
        public string PI_IdentityNumber { get; set; }
        public string PI_NationalCode { get; set; }
        public string PI_Capital { get; set; }
        public string PI_City { get; set; }
        public string PI_BirthdayDate { get; set; }
        public string PI_RegistrationDate { get; set; }
        public bool PI_IsMale { get; set; }

        //PersonalDocument
        public bool PI_IsNewIdentity { get; set; }
        public bool PI_IsNewNationalCard { get; set; }

        public IFormFile UploadPD_IdentityCard { get; set; }
        public string PD_IdentityCard { get; set; }

        public IFormFile UploadPD_NationalCardFrontSide { get; set; }
        public string PD_NationalCardFrontSide { get; set; }

        public IFormFile UploadPD_NationalCardBackSide { get; set; }
        public string PD_NationalCardBackSide { get; set; }

        public IFormFile UploadPD_NationalCodeTrackingPaper { get; set; }
        public string PD_NationalCodeTrackingPaper { get; set; }

        //BankInformation
        public string BI_BankName { get; set; }
        public string BI_BankAccountNumber { get; set; }
        public string BI_CreditCardNumber { get; set; }
        public string BI_ShabaNumber { get; set; }

        //BankDocument
        public bool BI_IsCreditCardWithFullInfo { get; set; }

        public IFormFile UploadBD_CreditCardFrontSide { get; set; }
        public string BD_CreditCardFrontSide { get; set; }

        public IFormFile UploadBD_CreditCardBackSide { get; set; }
        public string BD_CreditCardBackSide { get; set; }

        public IFormFile UploadBD_ShabaPrint { get; set; }
        public string BD_ShabaPrint { get; set; }

        //GuarantyInformation
        public bool GI_IsChequeGuarantyType { get; set; }
        public string GI_ChequeNumber { get; set; }
        public string GI_SafteNumber { get; set; }
        public string GI_ChequeBankBranch { get; set; }
        public string GI_ShenaseSayadiCheque { get; set; }

        //GuarantyDocument
        public IFormFile UploadGD_ChequeFrontSide { get; set; }
        public string GD_ChequeFrontSide { get; set; }

        public IFormFile UploadGD_ChequeBackSide { get; set; }
        public string GD_ChequeBackSide { get; set; }

        public IFormFile UploadGD_SafteFrontSide { get; set; }
        public string GD_SafteFrontSide { get; set; }

        public IFormFile UploadGD_SafteBackSide { get; set; }
        public string GD_SafteBackSide { get; set; }

    }
}
