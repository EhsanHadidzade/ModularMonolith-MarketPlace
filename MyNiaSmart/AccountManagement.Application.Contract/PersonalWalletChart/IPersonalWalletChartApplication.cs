using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.PersonalWalletChart
{
    public interface IPersonalWalletChartApplication
    {
        void Create(CreatePersonalWalletChart command);
    }
}
