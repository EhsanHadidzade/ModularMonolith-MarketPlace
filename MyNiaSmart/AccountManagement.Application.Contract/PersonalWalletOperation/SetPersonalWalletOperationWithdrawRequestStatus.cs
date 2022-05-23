using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.PersonalWalletOperation
{
    public class SetPersonalWalletOperationWithdrawRequestStatus
    {
        public int WithdrawRequestStatus { get; set; }
        public long PersonalWalletOperationId { get; set; }
    }
}
