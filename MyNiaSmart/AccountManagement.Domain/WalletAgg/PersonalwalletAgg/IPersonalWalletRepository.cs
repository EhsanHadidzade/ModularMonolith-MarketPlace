using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.WalletAgg.PersonalwalletAgg
{
    public interface IPersonalWalletRepository:IRepository<long,PersonalWallet>
    {
    }
}
