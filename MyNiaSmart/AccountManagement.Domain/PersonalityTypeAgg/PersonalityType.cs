using _0_Framework.Domain;
using AccountManagement.Domain.PersonalityAgg;
using System.Collections.Generic;

namespace AccountManagement.Domain.PersonalityTypeAgg
{
    public class PersonalityType:BaseEntity
    {
        public string Title { get; private set; }

        //relations
        public List<Personality> Personalities { get; private set; }

        public PersonalityType(string title)
        {
            Title = title;
            Personalities = new List<Personality>();
        }

        public void Edit(string title)
        {
            Title=title;
        }
    }
}
