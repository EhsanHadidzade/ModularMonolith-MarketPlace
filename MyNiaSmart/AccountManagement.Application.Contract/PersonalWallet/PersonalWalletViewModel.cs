using AccountManagement.Application.Contract.PersonalWalletChart;
using AccountManagement.Application.Contract.PersonalWalletOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.PersonalWallet
{
    public class PersonalWalletViewModel
    {
        public long Id { get; set; }
        public string CardNumber { get;  set; }
        public string OwnerFullName { get;  set; }
        public string OwnerRegistrationDate { get;  set; }
        public long Walletbalance { get; set; }
        public int Grade { get;  set; }
        public long UserId { get;  set; }
        public List<PersonalWalletOperationViewModel> PersonalWalletOperations { get; set; }
        public List<PersonalWalletChartViewModel> PersonalWalletCharts { get; set; }
    }
}
