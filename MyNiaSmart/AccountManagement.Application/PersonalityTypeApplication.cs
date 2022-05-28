using _0_Framework.Utilities;
using AccountManagement.Application.Contract.PersonalityType;
using AccountManagement.Domain.PersonalityTypeAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class PersonalityTypeApplication : IPersonalityTypeApplication
    {
        private readonly IPersonalityTypeRepository _personalityTypeRepository;

        public PersonalityTypeApplication(IPersonalityTypeRepository personalityTypeRepository)
        {
            _personalityTypeRepository = personalityTypeRepository;
        }

        public OperationResult Create(CreatePersonalityType command)
        {
            var operation=new OperationResult();
            if (_personalityTypeRepository.IsExist(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var personalityType = new PersonalityType(command.Title);
            _personalityTypeRepository.Create(personalityType);
            _personalityTypeRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditPersonalityType command)
        {
            var operation = new OperationResult();

            var personalityType = _personalityTypeRepository.GetById(command.Id);
            if (personalityType == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_personalityTypeRepository.IsExist(x=>x.Title==command.Title && x.Id!=command.Id))   
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            personalityType.Edit(command.Title);
            _personalityTypeRepository.Savechange();
            return operation.Succedded();

        }

        public EditPersonalityType GetDetails(long id)
        {
            return _personalityTypeRepository.GetDetails(id);
        }

        public List<PersonalityTypeViewModel> GetList()
        {
            return _personalityTypeRepository.GetList();
        }
    }
}
