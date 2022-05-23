using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.PersonalWalletOperation;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class PersonalWalletOperationRepository : BaseRepository<long, Personalwalletoperation>, IPersonalWalletOperationRepository
    {
        private readonly AccountContext _context;
        private readonly IPersonalWalletRepository _personalWalletRepository;

        public PersonalWalletOperationRepository(AccountContext context, IPersonalWalletRepository personalWalletRepository) : base(context)
        {
            _context = context;
            _personalWalletRepository = personalWalletRepository;
        }

        public Personalwalletoperation GetByVerifyCode(string verifyCode)
        {
            return _context.Personalwalletoperations.Include(x => x.PersonalWallet).FirstOrDefault(p => p.VerifyCode == verifyCode);
        }

        public List<PersonalWalletOperationViewModel> GetWithdrawRequests()
        {
            var withdrawRequests = _context.Personalwalletoperations.Select(x => new PersonalWalletOperationViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Description = x.Description,
                IsPay = x.IsPay,
                PersonalWalletId = x.PersonalWalletId,
                WalletOperationTypeId = x.WalletOperationTypeId,
                WithdrawStatus = x.WithdrawStatus,
                CreationDate = x.CreationDate.ToFarsiFull()
            }).Where(x => x.WalletOperationTypeId == PersonalWalletOperationType.Withdraw).OrderByDescending(x => x.Id).ToList();

            foreach (var item in withdrawRequests)
            {
                item.OwnerFullName = _personalWalletRepository.GetFullNameByPersonalWalletId(item.PersonalWalletId);
            }
            return withdrawRequests;
        }

        public List<PersonalWalletOperationViewModel> Get3LastWalletOperationsByWalletId(long personalWalletId)
        {
            return _context.Personalwalletoperations.Select(x => new PersonalWalletOperationViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                CreationDate = x.CreationDate.ToFarsiFull(),
                Description = x.Description,
                IsPay = x.IsPay,
                PersonalWalletId = x.PersonalWalletId,
                OwnerFullName = x.PersonalWallet.OwnerFullName,
                WalletOperationTypeId = x.WalletOperationTypeId,
                DepositeType = x.DepositeType,
                ReceiverFullName = x.ReceiverFullName,

            }).Where(x => x.IsPay).OrderByDescending(x => x.Id).Take(3).ToList();
        }

        //To Find All WalletOperations for show in profile and also for show in admin when admin is checking withdraw Request
        public List<PersonalWalletOperationViewModel> GetAllOperationsByWalletId(long personalWalletId)
        {
            return _context.Personalwalletoperations.Select(x => new PersonalWalletOperationViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                CreationDate = x.CreationDate.ToFarsiFull(),
                Description = x.Description,
                IsPay = x.IsPay,
                WithdrawStatus = x.WithdrawStatus,
                PersonalWalletId = x.PersonalWalletId,
                OwnerFullName = x.PersonalWallet.OwnerFullName,
                WalletOperationTypeId = x.WalletOperationTypeId,
                DepositeType = x.DepositeType,
                ReceiverFullName = x.ReceiverFullName,
                SenderFullName=x.SenderFullName
            }).Where(x => x.PersonalWalletId ==personalWalletId).OrderByDescending(x => x.Id).ToList();

        }

    }
}
