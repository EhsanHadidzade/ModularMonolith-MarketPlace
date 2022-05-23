using _0_Framework.Domain;
using AccountManagement.Application.Contract.BusinessWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.WalletAgg.BusinessWalletAgg
{
    public interface IBusinessWalletRepository:IRepository<long,BusinessWallet>
    {
        BusinessWalletViewModel GetWalletByUserId(long userId);
    }
}
