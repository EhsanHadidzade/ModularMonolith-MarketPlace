using _0_Framework.Domain;
using AccountManagement.Domain.PersonalityAgg;
using AccountManagement.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UserPersonalityAgg
{
    public class UserPersonality:BaseEntity
    {
        public long UserId { get;private set; }
        public long PersonalityId { get;private set; }


        //Relation with user and personality
        public User User { get; private set; }
        public Personality Personality{ get; private set; }

        public UserPersonality(long userId, long personalityId)
        {
            UserId = userId;
            PersonalityId = personalityId;
        }

        public void Edit(long userId, long personalityId)
        {
            UserId = userId;
            PersonalityId = personalityId;
        }
    }
}
