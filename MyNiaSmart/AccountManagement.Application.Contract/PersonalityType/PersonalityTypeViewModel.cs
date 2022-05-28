using AccountManagement.Application.Contract.Personality;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.PersonalityType
{
    public class PersonalityTypeViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<PersonalityViewModel> Personalities{ get; set; }
    }
}
