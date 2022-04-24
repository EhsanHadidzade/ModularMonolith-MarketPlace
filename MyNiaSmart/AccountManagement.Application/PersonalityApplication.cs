using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Personality;
using AccountManagement.Application.Contract.UserPersonality;
using AccountManagement.Domain.PersonalityAgg;
using AccountManagement.Domain.UserPersonalityAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class PersonalityApplication : IPersonalityApplication
    {
        private readonly IPersonalityRepository _personalityRepository;
        private readonly IUserPersonalityApplication _userPersonalityApplication;

        public PersonalityApplication(IPersonalityRepository personalityRepository, IUserPersonalityApplication userPersonalityApplication)
        {
            _personalityRepository = personalityRepository;
            _userPersonalityApplication = userPersonalityApplication;
        }

        public OperationResult Create(CreatePersonality command)
        {
            var operation = new OperationResult();
            if(_personalityRepository.IsExist(x=>x.Title == command.Title))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var personality = new Personality(command.Title);
            _personalityRepository.Create(personality);
            _personalityRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditPersonality command)
        {
            var operation = new OperationResult();
            var personality = _personalityRepository.GetById(command.Id);

            if (personality == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_personalityRepository.IsExist(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            personality.Edit(command.Title);
            _personalityRepository.Savechange();
            return operation.Succedded();
        }

        public Tuple<List<PersonalityViewModel>, List<long>, long> GetAllPersonalitiesWithSelectedPersonalitiesOfUserByUserId(long userId)
        {
            var personalities = _personalityRepository.GetList();
            var selectedPersonalities=_userPersonalityApplication.GetAllPersonalityIdsOfOneUserByUserId(userId);
            return Tuple.Create<List<PersonalityViewModel>, List<long>, long>(personalities,selectedPersonalities,userId);
        }

        public EditPersonality GetDetails(long id)
        {
            return _personalityRepository.GetDetails(id);
        }

        public List<PersonalityViewModel> Getlist()
        {
            return _personalityRepository.GetList();
        }
    }
}
