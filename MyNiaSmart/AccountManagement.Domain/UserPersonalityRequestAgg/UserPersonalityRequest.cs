using _0_Framework.Domain;
using AccountManagement.Domain.PersonalityAgg;
using AccountManagement.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UserPersonalityRequestAgg
{
    public class UserPersonalityRequest : BaseEntity
    {
        public long PersonalityId { get; private set; }
        public long UserId { get; private set; }

        //Relation with user and personality
        public Personality Personality { get; private set; }
        public User User { get; private set; }

        public UserPersonalityRequest(long personalityId, long userId)
        {
            PersonalityId = personalityId;
            UserId = userId;
        }
        public void Edit(long personalityId, long userId)
        {
            PersonalityId = personalityId;
            UserId = userId;
        }
    }
}
