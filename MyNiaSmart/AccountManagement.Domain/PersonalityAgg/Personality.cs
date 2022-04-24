using _0_Framework.Domain;
using AccountManagement.Domain.UserPersonalityAgg;
using System.Collections.Generic;

namespace AccountManagement.Domain.PersonalityAgg
{
    public class Personality:BaseEntity
    {
        #region Properties
        public string Title { get; private set; }
        #endregion

        #region relations
        public List<UserPersonality> UserPersonalities{ get; private set; }

        #endregion

        public Personality(string title)
        {
            Title = title;
            UserPersonalities = new List<UserPersonality>();
        }

        public void Edit(string title)
        {
            Title=title;
        }








    }
}
