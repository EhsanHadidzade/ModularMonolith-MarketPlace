using AccountManagement.Application.Contract.BusinessWallet;
using AccountManagement.Domain.WalletAgg.BusinessWalletAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Wallet
{
    public class BusinessWalletApplication : IBusinessWalletApplication
    {
        private readonly IBusinessWalletRepository _businessWalletRepository;

        public BusinessWalletApplication(IBusinessWalletRepository businessWalletRepository)
        {
            _businessWalletRepository = businessWalletRepository;
        }

        public BusinessWalletViewModel GetWalletByUserId(long userId)
        {
            return _businessWalletRepository.GetWalletByUserId(userId);
        }
    }
}
