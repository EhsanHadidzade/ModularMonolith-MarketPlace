using _0_Framework.Domain;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UserRoleAgg
{
    public interface IUserRoleRepository:IRepository<long,UserRole>
    {
        //To get list of userRoles Of one user . we use them for example in Removing UserRoles Method
        List<UserRole> GetUserRolesOfOneUserByUserId(long userId);

        //TO remove userRoles records of one specific user
        void RemoveUserRolesofOneUserByUserId(long userId);

        //to get list of roles that a user is Cooperating
        List<RoleViewModel> GetUserRolesByUserId(long userId);

    }
}
