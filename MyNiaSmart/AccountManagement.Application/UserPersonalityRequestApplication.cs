using AccountManagement.Application.Contract.UserPersonalityRequest;
using AccountManagement.Domain.UserPersonalityRequestAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class UserPersonalityRequestApplication : IUserPersonalityRequestApplication
    {
        private readonly IUserPersonalityRequestRepository _userPersonalityRequestRepository;

        public UserPersonalityRequestApplication(IUserPersonalityRequestRepository userPersonalityRequestRepository)
        {
            _userPersonalityRequestRepository = userPersonalityRequestRepository;
        }

        public void Create(CreateUserPersonalityRequestForSellerPanel command)
        {
            foreach (var personalityId in command.RequestedPersonalityIds)
            {
                var userPersonalityRequest = new UserPersonalityRequest(personalityId, command.UserId);
                _userPersonalityRequestRepository.Create(userPersonalityRequest);
            }
            _userPersonalityRequestRepository.Savechange();
        }
    }
}
