using AccountManagement.Application.Contract.PersonalWalletOperation;

namespace AccountManagement.Application.Contract.PersonalWallet
{
    public interface IPersonalWalletApplication
    {
        PersonalWalletViewModel GetWalletByUserId(long userId);
        PersonalWalletViewModel GetWalletByCardNumber(string cardNumber);

        //we use this when ever we need , but idont think we use this calculation . cus we saved wallet balance in its entity
        long CalculatePersonalWalletBalance(long personalWalletId);

        //to Get Balance of a wallet to check when they want to transfer or withdraw cash
        long GetBalanceByPersonalWalletId(long personalWalletId);


        //after a succedded transfration, we should reduce balance of sender and grow destination personal wallet balance,
        //creating wallet operation for them and also create wallet chart for them
        void ChangeBalanceOfSenderAndReceiver(TransferToAnotherWallet command);



    }
}
