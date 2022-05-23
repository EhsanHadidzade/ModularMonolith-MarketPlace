using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.BusinessWallet;
using AccountManagement.Domain.WalletAgg.BusinessWalletAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class BusinessWalletRepository : BaseRepository<long, BusinessWallet>, IBusinessWalletRepository
    {
        private readonly AccountContext _context;

        public BusinessWalletRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public BusinessWalletViewModel GetWalletByUserId(long userId)
        {
            return _context.BusinessWallets.Select(x=>new BusinessWalletViewModel 
            {
                Id = x.Id,
                CardNumber = long.Parse(x.CardNumber).ToString("0000-0000-0000-0000"),
                Grade=x.Grade,
                OwnerFullName=x.OwnerFullName,
                OwnerRegistrationDate=x.OwnerRegistrationDate,
                UserId=x.UserId
            }).FirstOrDefault(x=>x.UserId==userId);
        }
    }
}
