using _0_Framework.Infrastructure;
using AccountManagement.Domain.UserPersonalityRequestAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class UserPersonalityRequestRepository : BaseRepository<long, UserPersonalityRequest>, IUserPersonalityRequestRepository
    {
        private readonly AccountContext _context;

        public UserPersonalityRequestRepository(AccountContext context) : base(context)
        {
            _context = context;
        }
    }
}
