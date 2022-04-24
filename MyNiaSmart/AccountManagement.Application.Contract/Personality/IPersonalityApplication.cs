using _0_Framework.Utilities;
using System;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.Personality
{
    public interface IPersonalityApplication
    {
        OperationResult Create(CreatePersonality command);
        OperationResult Edit(EditPersonality command);
        List<PersonalityViewModel> Getlist();
        EditPersonality GetDetails(long id);

        //To Use in editUserPersonalityView as model
        Tuple<List<PersonalityViewModel>, List<long>, long> GetAllPersonalitiesWithSelectedPersonalitiesOfUserByUserId (long userId);
    }
}
