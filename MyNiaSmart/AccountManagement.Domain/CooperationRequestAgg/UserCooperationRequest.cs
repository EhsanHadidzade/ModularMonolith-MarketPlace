using _0_Framework.Domain;
using AccountManagement.Domain.PersonalityAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.CooperationRequestAgg
{
    public class UserCooperationRequest:BaseEntity
    {
        public long PersonalityId { get; private set; }
        public long UserId { get; private set; }

        //Relation with user and role
        public Personality Personality { get; private set; }
        public User User { get; private set; }

        public UserCooperationRequest(long personalityId, long userId)
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
