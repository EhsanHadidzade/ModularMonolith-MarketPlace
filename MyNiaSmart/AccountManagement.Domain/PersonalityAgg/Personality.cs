using _0_Framework.Domain;
using AccountManagement.Domain.CooperationRequestAgg;
using AccountManagement.Domain.PersonalityTypeAgg;
using AccountManagement.Domain.UserPersonalityAgg;
using AccountManagement.Domain.UserPersonalityRequestAgg;
using System.Collections.Generic;

namespace AccountManagement.Domain.PersonalityAgg
{
    public class Personality:BaseEntity
    {
        #region Properties
        public string Title { get; private set; }
        #endregion

        #region relations
        public long PersonalityTypeId { get;private set; }
        public PersonalityType PersonalityType{ get; private set; }
        public List<UserPersonality> UserPersonalities{ get; private set; }
        public List<UserPersonalityRequest> UserPersonalityRequests { get; private set; }
        public List<UserCooperationRequest> UserCooperationRequests { get; private set; }

        #endregion

        public Personality(string title,long personalityTypeId)
        {
            Title = title;
            PersonalityTypeId = personalityTypeId;
            UserPersonalities = new List<UserPersonality>();
            UserPersonalityRequests = new List<UserPersonalityRequest>();
        }

        public void Edit(string title, long personalityTypeId)
        {
            PersonalityTypeId=personalityTypeId;
            Title=title;
        }








    }
}
