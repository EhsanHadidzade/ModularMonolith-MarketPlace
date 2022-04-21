using _0_Framework.Utilities;
using AccountManagement.Application.Contract.UserRole;
using AccountManagement.Domain.UserRoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class UserRoleApplication : IUserRoleApplication
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleApplication(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public void CreateUserRoles(CreateUserRole command)
        {
            foreach(var roleId in command.SelectedRoleIds)
            {
                var userRole = new UserRole(roleId,command.UserId);
                _userRoleRepository.Create(userRole);
                _userRoleRepository.Savechange();
            }
        }

        public void EditUserRole(EditUserRole command)
        {
            //First, we remove All records of userRole table of one userId, then we add new records
            var userRoles=_userRoleRepository.GetUserRolesOfOneUserByUserId(command.UserId);
            foreach (var userRole in userRoles)
            {
                _userRoleRepository.RemoveUserRolesofOneUserByUserId(userRole.UserId);
                _userRoleRepository.Savechange();
            }
            foreach (var RoleId in command.SelectedRoleIds)
            {
                var userRole=new UserRole(RoleId,command.UserId);
                _userRoleRepository.Create(userRole);
                _userRoleRepository.Savechange();
            }
        }

        public List<long> GetAllRoleIdsOfOneUserByUserId(long userId)
        {
            var userRoles = _userRoleRepository.GetUserRolesOfOneUserByUserId(userId);
            var RoleIds = new List<long>();
            foreach (var userRole in userRoles)
            {
                RoleIds.Add(userRole.RoleId);
            }
            return RoleIds;
        }

        public void RemoveUserRolesofOneUserByUserId(long userId)
        {
            _userRoleRepository.RemoveUserRolesofOneUserByUserId(userId);
        }
    }
}
