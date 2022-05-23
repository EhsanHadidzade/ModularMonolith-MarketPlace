using _0_Framework.Domain;
using AccountManagement.Application.Contract.PersonalWalletOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg
{
    public interface IPersonalWalletOperationRepository:IRepository<long,Personalwalletoperation>
    {
        Personalwalletoperation GetByVerifyCode(string verifyCode);
        List<PersonalWalletOperationViewModel> GetWithdrawRequests();

        //To Get List of 3 last personal wallet operation
        List<PersonalWalletOperationViewModel> Get3LastWalletOperationsByWalletId(long personalWalletId);

        //To Find All WalletOperations for show in profile and also for show in admin when admin is checking withdraw Request
        public List<PersonalWalletOperationViewModel> GetAllOperationsByWalletId(long personalWalletId);

    }
}
