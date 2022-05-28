using _0_Framework.Domain;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.UserCooperationRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.CooperationRequestAgg
{
    public interface IUserCooperationRequestRepository:IRepository<long,UserCooperationRequest>
    {
        //To get list of RequestedRoles Of one user 
        List<UserCooperationRequest> GetAllUserRequestedPersonalitiesByUserId(long userId);

        //to check if a user is requested for cooperation or not to disable cooperationRequestButton
        bool IsUserRequestedForCooperation(long userId);

        //To Get List of people who requested for cooperation
        List<UserRequestedForCooperationViewModel> GetUsersWithCooperationRequest();

        //to use when admin is checking cooperation request and want to see requested roles
        List<RoleViewModel> GetRequestedRolesByRoleIds(List<long> roleIds);

        //to use for show in user profile to show them what role has they requested to cooperate
        List<RoleViewModel> GetRequestedPersonalitiesByUserId(long userId);

        //to check if user request for cooperation is recognized by admin or not
        bool IsUserRequestForCooperationRecognizedByAdmin(long userId);


    }
}
