using _0_Framework.Domain;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletChartAgg;
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
        public long WalletBalance { get;private set; }

        //its the grade of user that we save in their wallet
        public int Grade { get; private set; }

        //To save the dates that balance updates
        public DateTime BalanceUpdateDate { get; private set; }

        //relations
        public long UserId { get;private set; }
        public User User{ get; set; }

        public List<Personalwalletoperation> PersonalWalletOperations{ get; private set; }
        public List<PersonalWalletChart> PersonalWalletCharts{ get; private set; }


        public PersonalWallet(string cardNumber, string ownerFullName,
            string ownerRegistrationDate,int grade, long userId)
        {
            CardNumber = cardNumber;
            OwnerFullName = ownerFullName;
            OwnerRegistrationDate = ownerRegistrationDate;
            Grade = grade;
            UserId = userId;
            PersonalWalletOperations=new List<Personalwalletoperation>();
        }

        public void SaveBalanceUpdateDate(DateTime balanceUpdateDate)
        {
            BalanceUpdateDate = balanceUpdateDate;
        }

        public void IncreaseBalance(long amount)
        {
            WalletBalance=WalletBalance+amount;
        }

        public void DecreaseBalance(long amount)
        {
            WalletBalance = WalletBalance - amount;
        }
    }
}
