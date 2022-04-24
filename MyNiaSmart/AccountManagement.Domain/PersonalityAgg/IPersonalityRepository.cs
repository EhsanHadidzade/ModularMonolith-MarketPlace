using _0_Framework.Domain;
using AccountManagement.Application.Contract.Personality;
using System.Collections.Generic;

namespace AccountManagement.Domain.PersonalityAgg
{
    public interface IPersonalityRepository : IRepository<long, Personality>
    {
       
        EditPersonality GetDetails(long id);
        List<PersonalityViewModel> GetList();
    }
}
