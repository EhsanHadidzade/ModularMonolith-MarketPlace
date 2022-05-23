using _0_Framework.Domain;
using AccountManagement.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.WalletAgg.BusinessWalletAgg
{
    public class BusinessWallet:BaseEntity
    {
        public string CardNumber { get; private set; }
        public string OwnerFullName { get; private set; }
        public string OwnerRegistrationDate { get; private set; }
        public int Grade { get; private set; }

        //relations
        public long UserId { get; private set; }
        public User User { get; set; }



        public BusinessWallet(string cardNumber, string ownerFullName,
            string ownerRegistrationDate, int grade, long userId)
        {
            CardNumber = cardNumber;
            OwnerFullName = ownerFullName;
            OwnerRegistrationDate = ownerRegistrationDate;
            Grade = grade;
            UserId = userId;
        }
    }
}
