using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserCooperationRequest
{
    public interface IUserCooperationRequestApplication
    {
        OperationResult CreateUserCoopeartionRequest(CreateUserCooperationRequest command);

        //To get list of user RoleIds that requested to cooperate  
        List<long> GetAllRequestedRoleIdsByUserId(long userId);

        //to check if a user is requested for cooperation or not to disable cooperationRequestButton
        bool IsUserRequestedForCooperation(long userId);

        //To Get List of peeople who requested for cooperation
        List<UserRequestedForCooperationViewModel> GetUsersWithCooperationRequest();

        //to use when admin is checking cooperation request and want to see requested roles
        List<RoleViewModel> GetRequestedRolesByRoleIds(List<long> roleIds);

        //to use for show in user profile to show them what role has they requested to cooperate
        List<RoleViewModel> GetRequestedRolesByUserId(long userId);

        //to check if user request for cooperation is recognized by admin or not
        bool IsUserRequestForCooperationRecognizedByAdmin(long userId);


    }
}
