using _0_Framework.Utilities;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.PersonalityType
{
    public interface IPersonalityTypeApplication
    {
        OperationResult Create(CreatePersonalityType command);
        OperationResult Edit(EditPersonalityType command);
        List<PersonalityTypeViewModel> GetList();
        EditPersonalityType GetDetails(long id);
    }
}
