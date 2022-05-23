using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.UpAccountRequest;
using AccountManagement.Domain.UPAccountRequestsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class UpAccountRequestRepository : BaseRepository<long, UpAccountRequest>, IUPAccountRequestRepository
    {
        private readonly AccountContext _context;

        public UpAccountRequestRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public void DeactiveClientConfirmation(long requestId)
        {
            var request=GetById(requestId);
            request.RejectRequestWithClient();
            _context.SaveChanges();
        }

        public EditUpAccountRequest GetDetails(long id)
        {
            return _context.UpAccountRequests.Select(x=>new EditUpAccountRequest
            {
                Id=x.Id,
                PI_FUllName=x.PI_FUllName,
                PI_FatherName=x.PI_FatherName,
                PI_IsMale=x.PI_IsMale,
                PI_IdentityNumber=x.PI_IdentityNumber,
                PI_City=x.City,
                PI_Capital=x.Capital,
                PI_RegistrationDate=x.PI_RegistrationDate.ToFarsi(),
                PI_BirthdayDate=x.PI_BirthdayDate.ToFarsi(),
                PI_NationalCode=x.PI_NationalCode,
                PI_IsNewIdentity=x.PI_IsNewIdentity,
                PI_IsNewNationalCard=x.PI_IsNewNationalCard,
                PD_IdentityCard=x.PD_IdentityCard,
                PD_NationalCardBackSide=x.PD_NationalCardBackSide,
                PD_NationalCardFrontSide=x.PD_NationalCardFrontSide,
                PD_NationalCodeTrackingPaper=x.PD_NationalCodeTrackingPaper,
                BI_BankAccountNumber=x.BI_BankAccountNumber,
                BI_BankName=x.BI_BankName,
                BI_CreditCardNumber=x.BI_CreditCardNumber,
                BI_IsCreditCardWithFullInfo=x.BI_IsCreditCardWithFullInfo,
                BI_ShabaNumber=x.BI_ShabaNumber,
                BD_CreditCardBackSide=x.BD_CreditCardBackSide,
                BD_CreditCardFrontSide=x.BD_CreditCardFrontSide,
                BD_ShabaPrint=x.BD_ShabaPrint,
                GI_ChequeBankBranch=x.GI_ChequeBankBranch,
                GI_ChequeNumber=x.GI_ChequeNumber,
                GI_IsChequeGuarantyType=x.GI_IsChequeGuarantyType,
                GI_SafteNumber=x.GI_SafteNumber,
                GI_ShenaseSayadiCheque=x.GI_ShenaseSayadiCheque,
                GD_ChequeBackSide=x.GD_ChequeBackSide,
                GD_ChequeFrontSide=x.GD_ChequeFrontSide,
                GD_SafteBackSide=x.GD_SafteBackSide,
                GD_SafteFrontSide=x.GD_SafteFrontSide

            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<UpAccountRequestViewModel> GetList()
        {
            return _context.UpAccountRequests.Select(x=>new UpAccountRequestViewModel
            {
                Id=x.Id,
                FullName=x.PI_FUllName,
                City=x.City,
                Capital=x.Capital,
                IsConfirmedByAdmin=x.IsRequestConfirmedByAdmin,
                IsConfirmedByClient=x.IsRequestConfirmedByClient
            }).ToList();
        }

        public bool IsUpAccountRequestConfirmedByAdmin(long userId)
        {
            var req = _context.UpAccountRequests.Select(x=>new {x.IsRequestConfirmedByAdmin,x.UserId}).Where(x => x.UserId==userId).FirstOrDefault();
            return req.IsRequestConfirmedByAdmin;
        }

        public bool HasUserRequestedForUpAccount(long userId)
        {
            return _context.UpAccountRequests.Any(x => x.UserId == userId);
        }
        
        public UpAccountRequestViewModel GetByUserId(long userId)
        {
            var req= _context.UpAccountRequests.Select(x=>new UpAccountRequestViewModel
            {
                Id=x.Id,
                IsConfirmedByAdmin=x.IsRequestConfirmedByAdmin,
                IsConfirmedByClient=x.IsRequestConfirmedByClient,
                UserId=x.UserId
            }).FirstOrDefault(x=>x.UserId==userId);
            return req;
        }
    }
}
