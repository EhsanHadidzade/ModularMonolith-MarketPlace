using AccountManagement.Application.Contract.PersonalWalletChart;
using AccountManagement.Domain.WalletAgg.PersonalWalletChartAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Wallet
{
    public class PersonalWalletChartApplication : IPersonalWalletChartApplication
    {
        private readonly IPersonalWalletChartRepository _personalWalletChartRepository;

        public PersonalWalletChartApplication(IPersonalWalletChartRepository personalWalletChartRepository)
        {
            _personalWalletChartRepository = personalWalletChartRepository;
        }

        public void Create(CreatePersonalWalletChart command)
        {
            var chart = new PersonalWalletChart(command.Balance, command.BalanceUpdateDate, command.PersonalWalletId);
            _personalWalletChartRepository.Create(chart);
            _personalWalletChartRepository.Savechange();

        }
    }
}
