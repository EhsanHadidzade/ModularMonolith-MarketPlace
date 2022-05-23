using _0_Framework.Utilities;
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
            foreach (var roleId in command.SelectedRoleIds)
            {
                if (_userCooperationRequestRepository.IsExist(x => x.UserId == command.UserId && x.RoleId == roleId))
                {
                    return operation.Failed(ApplicationMessage.DuplicatedRecord);
                }
                var RequestedRoleId = new UserCooperationRequest(roleId, command.UserId);
                _userCooperationRequestRepository.Create(RequestedRoleId);
                _userCooperationRequestRepository.Savechange();
            }
            return operation.Succedded("درخواست همکاری شما با موفقیت ثبت و نتیجه آن در پنل کاربری شما قابل مشاهده خواهد بود");

        }

        public List<long> GetAllRequestedRoleIdsByUserId(long userId)
        {
            var requestedRoles = _userCooperationRequestRepository.GetAllUserRequestedRolesByUserId(userId);
            var requestedRoleIds = new List<long>();
            foreach (var item in requestedRoles)
            {
                requestedRoleIds.Add(item.RoleId);
            }
            return requestedRoleIds;
        }

        public List<RoleViewModel> GetRequestedRolesByRoleIds(List<long> roleIds)
        {
            return _userCooperationRequestRepository.GetRequestedRolesByRoleIds(roleIds);
        }

        public List<RoleViewModel> GetRequestedRolesByUserId(long userId)
        {
            return _userCooperationRequestRepository.GetRequestedRolesByUserId(userId);
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
