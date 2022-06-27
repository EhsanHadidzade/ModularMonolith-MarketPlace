using _0_Framework.Domain;
using AccountManagement.Application.Contract.PersonalWallet;
using AccountManagement.Application.Contract.PersonalWalletOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.WalletAgg.PersonalwalletAgg
{
    public interface IPersonalWalletRepository:IRepository<long,PersonalWallet>
    {
        
        PersonalWallet GetByCardNumber(string cardNumber);
        PersonalWallet GetByuserId(long userId);
        string GetFullNameByPersonalWalletId(long personalWalletId);

        //To use when user want to transfer cash to another wallet and we want to save receiver full name 
        string GetFullNameByCardNumber(string cardNumber);

        long CalculatePersonalWalletBalance(long personalWalletId);
        long GetBalanceByPersonalWalletId(long personalWalletId);

        //using when user want to pay specific order with his wallet
        long GetBalanceByUserId(long userId);

        PersonalWalletViewModel GetWalletByUserId(long userId);
        PersonalWalletViewModel GetWalletByCardNumber(string cardNumber);
    }
}
