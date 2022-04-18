using System.Collections.Generic;

namespace AccountManagement.Application.Contract.UserRole
{
    
    public interface IUserRoleApplication
    {
        void CreateUserRoles(CreateUserRole command);
        void EditUserRole(EditUserRole command);

        //To get list of user RoleIds for show in edit form
        List<long> GetAllRoleIdsOfOneUserByUSerId(long userId);

    }
}
