using _0_Framework.Infrastructure;
using AccountManagement.Domain.UserPersonalityAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class UserPersonalityRepository : BaseRepository<long, UserPersonality>, IUserPersonalityRepository
    {
        private readonly AccountContext _context;

        public UserPersonalityRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public List<UserPersonality> GetUserPersonalitiesOfOneUserByUserId(long userId)
        {
            return _context.UserPersonalities.Where(x => x.UserId == userId).ToList();
        }

        public void RemoveUserPersonalitiesOfOneUserByUserId(long userId)
        {
            var userPersonalities=GetUserPersonalitiesOfOneUserByUserId(userId);
            foreach (var item in userPersonalities)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
