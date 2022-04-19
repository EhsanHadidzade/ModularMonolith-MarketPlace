using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class RoleRepository:BaseRepository<long,Role>,IRoleRepository
    {
        private readonly AccountContext _context;

        public RoleRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public EditRole GetDetails(long id)
        {
            return _context.Roles.Select(x=>new EditRole
            {
                Id =x.Id,
                Name = x.Name,
                RoleTypeId = x.RoleTypeId,
                
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<RoleViewModel> GetList()
        {
            return _context.Roles.Include(x=>x.RoleType).Select(x=>new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                RoleTypeName=x.RoleType.RoleTypeName,
                CreationDate=x.CreationDate.ToFarsi()
            }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}
