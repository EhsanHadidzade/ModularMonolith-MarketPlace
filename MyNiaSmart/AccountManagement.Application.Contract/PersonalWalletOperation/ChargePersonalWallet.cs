using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.PersonalWalletOperation
{
    public class ChargePersonalWallet
    {
        public long PersonalWalletId { get; set; }
        public long WalletOperationTypeId { get; set; }
        public long Amount { get; set; }
    }
}
