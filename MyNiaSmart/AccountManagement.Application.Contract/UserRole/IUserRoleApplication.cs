using System;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.UserRole
{
    
    public interface IUserRoleApplication
    {
        void CreateUserRoles(CreateUserRole command);
        void EditUserRole(EditUserRole command);

        //To get list of user RoleIds for show in edit form
        List<long> GetAllRoleIdsOfOneUserByUserId(long userId);


        //TO remove userRoles records of one specific user
        void RemoveUserRolesofOneUserByUserId(long userId);

    }
}
