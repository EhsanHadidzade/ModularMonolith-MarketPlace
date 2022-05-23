using _0_Framework.Domain;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.WalletAgg.PersonalWalletChartAgg
{
    public class PersonalWalletChart
    {
        public long Id { get; set; }
        public long Balance { get;private set; }
        public DateTime BalanceUpdateDate { get;private set; }

        //relations
        public long PersonalwalletId { get; private set; }
        public PersonalWallet PersonalWallet{ get;private set; }

        public PersonalWalletChart(long balance, DateTime balanceUpdateDate, long personalwalletId)
        {
            Balance = balance;
            BalanceUpdateDate = balanceUpdateDate;
            PersonalwalletId = personalwalletId;
        }
    }
}
