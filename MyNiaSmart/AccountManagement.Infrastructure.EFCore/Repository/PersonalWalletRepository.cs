using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.PersonalWallet;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using _0_Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg;
using AccountManagement.Application.Contract.PersonalWalletOperation;
using AccountManagement.Application.Contract.PersonalWalletChart;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class PersonalWalletRepository : BaseRepository<long, PersonalWallet>, IPersonalWalletRepository
    {
        private readonly AccountContext _context;
        //private readonly IPersonalWalletOperationRepository _personalWalletOperationRepository;

        public PersonalWalletRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public PersonalWalletViewModel GetWalletByCardNumber(string cardNumber)
        {
            return _context.PersonalWallets.Select(x => new PersonalWalletViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                OwnerFullName = x.OwnerFullName,
                CardNumber = x.CardNumber,
                Walletbalance = x.WalletBalance,
                OwnerRegistrationDate = x.OwnerRegistrationDate,
                Grade = x.Grade
            }).FirstOrDefault(p => p.CardNumber == cardNumber);
        }

        public PersonalWalletViewModel GetWalletByUserId(long userId)
        {
            var personalwallet= _context.PersonalWallets.Select(x => new PersonalWalletViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                CardNumber = long.Parse(x.CardNumber).ToString("0000-0000-0000-0000"),
                Grade = x.Grade,
                Walletbalance = x.WalletBalance,
                OwnerFullName = x.OwnerFullName,
                OwnerRegistrationDate = x.OwnerRegistrationDate,
            }).FirstOrDefault(x => x.UserId == userId);
         
            personalwallet.PersonalWalletOperations= _context.Personalwalletoperations.Select(x => new PersonalWalletOperationViewModel
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
                SenderFullName= x.SenderFullName
            }).Where(x =>x.PersonalWalletId==personalwallet.Id).OrderByDescending(x => x.Id).ToList();

            personalwallet.PersonalWalletCharts = _context.PersonalWalletCharts.Select(x => new PersonalWalletChartViewModel
            {
                Balance = x.Balance,
                BalanceUpdateDate = x.BalanceUpdateDate.ToFarsiFull(),
                PersonalWalletId = x.PersonalwalletId
            }).Where(x => x.PersonalWalletId == personalwallet.Id).ToList();

            return personalwallet;

        }

      
        public long CalculatePersonalWalletBalance(long personalWalletId)
        {
            var depositeAmount = _context.Personalwalletoperations
                .Where(x => x.PersonalWalletId == personalWalletId &&
                x.WalletOperationTypeId == PersonalWalletOperationType.Deposite && x.IsPay == true).Select(x => x.Amount).ToList().Sum();

            var recieveAmount = _context.Personalwalletoperations
               .Where(x => x.PersonalWalletId == personalWalletId &&
               x.WalletOperationTypeId == PersonalWalletOperationType.Receive && x.IsPay == true).Select(x => x.Amount).ToList().Sum();

            var withdrawAmount = _context.Personalwalletoperations
               .Where(x => x.PersonalWalletId == personalWalletId &&
               x.WalletOperationTypeId == PersonalWalletOperationType.Withdraw && x.IsPay == true).Select(x => x.Amount).ToList().Sum();

            var TransferAmount = _context.Personalwalletoperations
               .Where(x => x.PersonalWalletId == personalWalletId &&
               x.WalletOperationTypeId == PersonalWalletOperationType.Transfer && x.IsPay == true).Select(x => x.Amount).ToList().Sum();

            return depositeAmount + recieveAmount - withdrawAmount - TransferAmount;


        }

        public PersonalWallet GetByCardNumber(string cardNumber)
        {
            return _context.PersonalWallets.FirstOrDefault(x => x.CardNumber == cardNumber);
        }

        public PersonalWallet GetByuserId(long userId)
        {
            return _context.PersonalWallets.FirstOrDefault(x => x.UserId == userId);
        }

        public long GetBalanceByPersonalWalletId(long personalWalletId)
        {
            return _context.PersonalWallets.Select(x => new { x.Id, x.WalletBalance }).FirstOrDefault(x => x.Id == personalWalletId).WalletBalance;
        }

        public string GetFullNameByPersonalWalletId(long personalWalletId)
        {
            var wallet = _context.PersonalWallets.Select(x => new {x.Id,x.OwnerFullName}).FirstOrDefault(x => x.Id == personalWalletId);
            return wallet.OwnerFullName;

        }

        public string GetFullNameByCardNumber(string cardNumber)
        {
            return _context.PersonalWallets.Select(x => new { x.CardNumber, x.OwnerFullName }).FirstOrDefault(x => x.CardNumber == cardNumber).OwnerFullName;
        }
    }
}
