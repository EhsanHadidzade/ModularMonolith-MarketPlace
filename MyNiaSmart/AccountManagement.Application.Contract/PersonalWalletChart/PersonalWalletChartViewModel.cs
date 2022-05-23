using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.PersonalWalletChart
{
    public class PersonalWalletChartViewModel
    {
        public long PersonalWalletId { get; set; }
        public string BalanceUpdateDate { get; set; }
        public long Balance { get; set; }
    }
}
