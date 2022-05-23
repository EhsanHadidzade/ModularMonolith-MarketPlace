using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Role;
using System;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.UserRole
{

    public interface IUserRoleApplication
    {
        OperationResult CreateUserRoles(CreateUserRole command);
        void EditUserRole(EditUserRole command);

        //To get list of user RoleIds for show in edit form
        List<long> GetAllRoleIdsOfOneUserByUserId(long userId);


        //TO remove userRoles records of one specific user
        void RemoveUserRolesofOneUserByUserId(long userId);

        //to get list of roles that a user is Cooperating
        List<RoleViewModel> GetUserRolesByUserId(long userId);

    }
}
