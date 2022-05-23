using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.BusinessWallet
{
    public class BusinessWalletViewModel
    {
        public long Id { get; set; }
        public string CardNumber { get; set; }
        public string OwnerFullName { get; set; }
        public string OwnerRegistrationDate { get; set; }
        public int Grade { get; set; }
        public long UserId { get; set; }
    }
}
