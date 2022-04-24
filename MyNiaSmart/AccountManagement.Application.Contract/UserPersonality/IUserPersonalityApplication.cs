using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserPersonality
{
    public interface IUserPersonalityApplication
    {
        void CreateUserPersonalities(CreateUserPersonality command);
        void EditUserPersonality(EditUserPersonality command);

        //To get list of user PersonalityIds for show in edit form
        List<long> GetAllPersonalityIdsOfOneUserByUserId(long userId);

        //TO remove userRoles records of one specific user
        void RemoveUserPersonalitiesofOneUserByUserId(long userId);
    }
}
