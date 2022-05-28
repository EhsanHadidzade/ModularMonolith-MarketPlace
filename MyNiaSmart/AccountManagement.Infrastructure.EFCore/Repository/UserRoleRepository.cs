using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.UserRole;
using AccountManagement.Domain.UserRoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class UserRoleRepository : BaseRepository<long, UserRole>, IUserRoleRepository

    {
        private readonly AccountContext _context;

        public UserRoleRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public List<RoleViewModel> GetUserRolesByUserId(long userId)
        {
            var userRoleIds = _context.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleId).ToList();
            var userRoles = new List<RoleViewModel>();
            foreach (var roleId in userRoleIds)
            {
                var role = _context.Roles.Select(x => new RoleViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).FirstOrDefault(x => x.Id == roleId);
                userRoles.Add(role);
            }
            return userRoles;
        }

        public List<UserRole> GetUserRolesOfOneUserByUserId(long userId)
        {
            return _context.UserRoles.Where(x => x.UserId == userId).ToList();
        }

        public void RemoveUserRolesofOneUserByUserId(long userId)
        {
            var userRoles = GetUserRolesOfOneUserByUserId(userId);
            foreach (var userRole in userRoles)
            {
                _context.UserRoles.Remove(userRole);
                _context.SaveChanges();
            }
        }
    }
}
