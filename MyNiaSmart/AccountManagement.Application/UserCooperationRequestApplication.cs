using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Personality;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.UserCooperationRequest;
using AccountManagement.Domain.CooperationRequestAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class UserCooperationRequestApplication : IUserCooperationRequestApplication
    {
        private readonly IUserCooperationRequestRepository _userCooperationRequestRepository;

        public UserCooperationRequestApplication(IUserCooperationRequestRepository userCooperationRequestRepository)
        {
            _userCooperationRequestRepository = userCooperationRequestRepository;
        }

        public OperationResult CreateUserCoopeartionRequest(CreateUserCooperationRequest command)
        {
            var operation = new OperationResult();
            foreach (var personalityId in command.SelectedPersonalityIds)
            {
                if (_userCooperationRequestRepository.IsExist(x => x.UserId == command.UserId && x.PersonalityId == personalityId))
                {
                    return operation.Failed(ApplicationMessage.DuplicatedRecord);
                }
                var RequestedPersonalityId = new UserCooperationRequest(personalityId, command.UserId);
                _userCooperationRequestRepository.Create(RequestedPersonalityId);
                _userCooperationRequestRepository.Savechange();
            }
            return operation.Succedded("درخواست همکاری شما با موفقیت ثبت و نتیجه آن در پنل کاربری شما قابل مشاهده خواهد بود");

        }

        public List<long> GetAllRequestedPersonalityIdsByUserId(long userId)
        {
            var requestedPersonalities = _userCooperationRequestRepository.GetAllUserRequestedPersonalitiesByUserId(userId);
            var requestedRoleIds = new List<long>();
            foreach (var item in requestedPersonalities)
            {
                requestedRoleIds.Add(item.PersonalityId);
            }
            return requestedRoleIds;
        }

        public List<PersonalityViewModel> GetRequestedPersonalitiesByPersonalityIds(List<long> personalityIds)
        {
            return _userCooperationRequestRepository.GetRequestedPersonalitiesByPersonalityIds(personalityIds);
        }

        public List<PersonalityViewModel> GetRequestedPersonalitiesByUserId(long userId)
        {
            return _userCooperationRequestRepository.GetRequestedPersonalitiesByUserId(userId);
        }

        public List<UserRequestedForCooperationViewModel> GetUsersWithCooperationRequest()
        {
            return _userCooperationRequestRepository.GetUsersWithCooperationRequest();
        }

        public bool IsUserRequestedForCooperation(long userId)
        {
            return _userCooperationRequestRepository.IsUserRequestedForCooperation(userId);
        }

        public bool IsUserRequestForCooperationRecognizedByAdmin(long userId)
        {
            return _userCooperationRequestRepository.IsUserRequestForCooperationRecognizedByAdmin(userId);
        }

    }
}
