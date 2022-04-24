using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UserPersonalityAgg
{
    public interface IUserPersonalityRepository:IRepository<long,UserPersonality>
    {
        //To get list of userPersonalities Of one user . we use them for example in Removing UserPersonalities Method
        List<UserPersonality> GetUserPersonalitiesOfOneUserByUserId(long userId);

        //TO remove userPersonalities records of one specific user
        void RemoveUserPersonalitiesOfOneUserByUserId(long userId);
    }
}
