using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.PersonalWalletChart
{
    public class CreatePersonalWalletChart
    {
        public long PersonalWalletId { get; set; }
        public long Balance { get; set; }
        public DateTime BalanceUpdateDate { get; set; }
    }
}
