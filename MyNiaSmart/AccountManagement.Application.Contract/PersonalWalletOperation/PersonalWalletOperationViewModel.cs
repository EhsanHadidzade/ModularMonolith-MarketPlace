using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.PersonalWalletOperation
{
    public class PersonalWalletOperationViewModel
    {
        public long Id { get; set; }
        public string OwnerFullName { get; set; }
        public string CreationDate { get; set; }
        public long Amount { get;  set; }
        public bool IsPay { get;  set; }
        public int WithdrawStatus { get; set; }
        public int DepositeType { get; set; }
        public string Description { get;  set; }
        public string VerifyCode { get; set; }
        public long PersonalWalletId { get;  set; }
        public long WalletOperationTypeId { get;  set; }
        public string ReceiverFullName { get; set; }
        public string SenderFullName { get; set; }


    }
}
