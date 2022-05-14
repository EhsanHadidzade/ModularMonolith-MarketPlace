using _0_Framework.Domain;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.WalletAgg.PersonalwalletAgg
{
    public class PersonalWallet:BaseEntity
    {
        public string CardNumber { get;private set; }
        public string OwnerFullName { get; private set; }
        public string OwnerRegistrationDate { get;private set; }

        //relations
        public long UserId { get;private set; }
        public User User{ get; set; }

        public List<Personalwalletoperation> PersonalWalletOperations{ get; private set; }


        public PersonalWallet(string cardNumber, string ownerFullName,
            string ownerRegistrationDate, long userId)
        {
            CardNumber = cardNumber;
            OwnerFullName = ownerFullName;
            OwnerRegistrationDate = ownerRegistrationDate;
            UserId = userId;
            PersonalWalletOperations=new List<Personalwalletoperation>();
        }
    }
}
