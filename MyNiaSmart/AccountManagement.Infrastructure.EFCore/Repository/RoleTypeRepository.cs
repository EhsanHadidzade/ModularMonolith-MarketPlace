using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.RoleType;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.RoleTypeAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class RoleTypeRepository : BaseRepository<long, RoleType>, IRoleTypeRepository
    {
        private readonly AccountContext _context;

        public RoleTypeRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public EditRoleType GetDetails(long id)
        {
            return _context.RoleTypes.Select(x=>new EditRoleType
            {
                Id =x.Id,
                RoleTypeName=x.RoleTypeName
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<RoleTypeViewModel> GetList()
        {
            return _context.RoleTypes.Select(x => new RoleTypeViewModel
            {
                Id = x.Id,
                RoleTypeName = x.RoleTypeName,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved,
               Roles=MapRoles(x.Roles)
            }).OrderByDescending(x=>x.Id).ToList();
        }

        private static List<RoleViewModel> MapRoles(List<Role> roles)
        {
            return roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                RoleTypeId=x.RoleTypeId
            }).ToList();
        }
    }
}
