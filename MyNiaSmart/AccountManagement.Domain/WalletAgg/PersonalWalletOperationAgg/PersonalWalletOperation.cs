using _0_Framework.Domain;
using AccountManagement.Domain.WalletAgg.OperationTypeAgg;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg
{
    public class Personalwalletoperation:BaseEntity
    {
        public long Amount { get; private set; }
        public bool IsPay { get; private set; }
        public string Description { get; private set; }

        //relations
        public PersonalWallet PersonalWallet { get; private set; }
        public long PersonalWalletId { get; private set; }

        public long WalletOperationTypeId { get; private set; }
        public WalletOperationType WalletOperationType { get;private set; }

        public Personalwalletoperation(long amount, bool isPay, string description,
            long personalWalletId, long walletOperationTypeId)
        {
            Amount = amount;
            IsPay = isPay;
            Description = description;
            PersonalWalletId = personalWalletId;
            WalletOperationTypeId = walletOperationTypeId;
        }
    }
}
