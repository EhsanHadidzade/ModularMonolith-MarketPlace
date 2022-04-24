using AccountManagement.Application.Contract.UserPersonality;
using AccountManagement.Domain.UserPersonalityAgg;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class UserPersonalityApplication : IUserPersonalityApplication
    {
        private readonly IUserPersonalityRepository _userPersonalityRepository;

        public UserPersonalityApplication(IUserPersonalityRepository userPersonalityRepository)
        {
            _userPersonalityRepository = userPersonalityRepository;
        }

        public void CreateUserPersonalities(CreateUserPersonality command)
        {
            foreach (var item in command.SelectedPersonalityIds)
            {
                var userPersonality = new UserPersonality(command.UserId, item);
                _userPersonalityRepository.Create(userPersonality);
                _userPersonalityRepository.Savechange();
            }
        }

        public void EditUserPersonality(EditUserPersonality command)
        {
           var userPersonalities= _userPersonalityRepository.GetUserPersonalitiesOfOneUserByUserId(command.UserId);
            foreach (var userPersonality in userPersonalities)
            {
                _userPersonalityRepository.RemoveUserPersonalitiesOfOneUserByUserId(userPersonality.UserId);
                _userPersonalityRepository.Savechange();
            }
            foreach (var item in command.SelectedPersonalityIds)
            {
                var userPersonality=new UserPersonality(command.UserId, item);
                _userPersonalityRepository.Create(userPersonality);
                _userPersonalityRepository.Savechange();
            }
        }

        public List<long> GetAllPersonalityIdsOfOneUserByUserId(long userId)
        {
            var userPersonalities = _userPersonalityRepository.GetUserPersonalitiesOfOneUserByUserId(userId);
            var PersonalityIds = new List<long>();
            foreach (var userPersonality in userPersonalities)
            {
                PersonalityIds.Add(userPersonality.PersonalityId);
            }
            return PersonalityIds;
        }

        public void RemoveUserPersonalitiesofOneUserByUserId(long userId)
        {
            _userPersonalityRepository.RemoveUserPersonalitiesOfOneUserByUserId(userId);
        }
    }
}
