using _0_Framework.Contract;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.PersonalWallet;
using AccountManagement.Application.Contract.PersonalWalletOperation;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletChartAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Wallet
{
    public class PersonalWalletApplication : IPersonalWalletApplication
    {
        private readonly IPersonalWalletRepository _personalWalletRepository;
        private readonly IPersonalWalletChartRepository _personalWalletChartRepository;
        private readonly IAuthHelper _authHelper;

        public PersonalWalletApplication(IPersonalWalletRepository personalWalletRepository, IAuthHelper authHelper,
            IPersonalWalletChartRepository personalWalletChartRepository)
        {
            _personalWalletRepository = personalWalletRepository;
            _authHelper = authHelper;
            _personalWalletChartRepository = personalWalletChartRepository;
        }


        public PersonalWalletViewModel GetWalletByCardNumber(string cardNumber)
        {
            return _personalWalletRepository.GetWalletByCardNumber(cardNumber);
        }

        public PersonalWalletViewModel GetWalletByUserId(long userId)
        {
            return _personalWalletRepository.GetWalletByUserId(userId);
        }

        public void ChangeBalanceOfSenderAndReceiver(TransferToAnotherWallet command)
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var senderPersonalWallet = _personalWalletRepository.GetByuserId(userId);
            var receiverPersonalWallet = _personalWalletRepository.GetByCardNumber(command.DestinationCardNumber);

            senderPersonalWallet.DecreaseBalance(command.Amount);
            receiverPersonalWallet.IncreaseBalance(command.Amount);

            //creating a new pesonal wallet operation for receiver 
            var receiveOperation = new Personalwalletoperation(command.Amount, true, PersonalWalletOperationTitle.Receive, receiverPersonalWallet.Id,
                PersonalWalletOperationType.Receive);
            receiveOperation.SetSenderFullName(senderPersonalWallet.OwnerFullName);
            receiverPersonalWallet.PersonalWalletOperations.Add(receiveOperation);
            _personalWalletRepository.Savechange();

            //creating a new personal wallet chart for sender and receiver
            var senderWalletchart=new PersonalWalletChart(senderPersonalWallet.WalletBalance,DateTime.Now,senderPersonalWallet.Id);
            _personalWalletChartRepository.Create(senderWalletchart);

            var receiverWalletChart=new PersonalWalletChart(receiverPersonalWallet.WalletBalance,DateTime.Now,receiverPersonalWallet.Id);
            _personalWalletChartRepository.Create(receiverWalletChart);
            _personalWalletRepository.Savechange();
        }

        public long CalculatePersonalWalletBalance(long personalWalletId)
        {
            return _personalWalletRepository.CalculatePersonalWalletBalance(personalWalletId);
        }

        public long GetBalanceByPersonalWalletId(long personalWalletId)
        {
            return _personalWalletRepository.GetBalanceByPersonalWalletId(personalWalletId);
        }
    }
}
