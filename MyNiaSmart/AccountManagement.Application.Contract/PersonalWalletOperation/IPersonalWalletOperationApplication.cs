using _0_Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.PersonalWalletOperation
{
    public interface IPersonalWalletOperationApplication
    {
        //to charge personal wallet
        long ChargePersonalWallet(ChargePersonalWallet command);

        //transfer to another personal wallet
        OperationResult TransferToAnotherWallet(TransferToAnotherWallet command);

        //to check if dynamic code for transfer cash is verified
        OperationResult CheckDynamicCode(string verifyCode);

        //To send request from client if they want to withdraw money from their personal wallet
        OperationResult WithdrawPersonalWallet(WithdrawPersonalWallet command);

        //To Get Withdraw requests of clients that want to withdraw money from their personal wallet
        List<PersonalWalletOperationViewModel> GetWithdrawRequests();

        //To Find All WalletOperations for show in profile and also for show in admin when admin is checking withdraw Request
        public List<PersonalWalletOperationViewModel> GetAllOperationsByWalletId(long personalWalletId);

        //to set status of an specific withdraw request
        void SetWithdrawRequestStatus(SetPersonalWalletOperationWithdrawRequestStatus command);


        #region For Pay order by wallet
        OperationResult PayOrder(long amount);
        #endregion






    }
}
