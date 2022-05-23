using _0_Framework.Infrastructure;
using AccountManagement.Domain.WalletAgg.PersonalWalletChartAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class PersonalWalletChartRepository: BaseRepository<long,PersonalWalletChart>,IPersonalWalletChartRepository
    {
        private readonly AccountContext _context;

        public PersonalWalletChartRepository(AccountContext context):base(context)
        {
            _context = context;
        }
    }
}
