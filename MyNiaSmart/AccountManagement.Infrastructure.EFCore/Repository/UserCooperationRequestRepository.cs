using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.UserCooperationRequest;
using AccountManagement.Domain.CooperationRequestAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class UserCooperationRequestRepository : BaseRepository<long, UserCooperationRequest>, IUserCooperationRequestRepository
    {
        private readonly AccountContext _context;

        public UserCooperationRequestRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public List<UserCooperationRequest> GetAllUserRequestedRolesByUserId(long userId)
        {
            return _context.UserCooperationRequests.Where(x => x.UserId == userId).ToList();
        }

        public List<RoleViewModel> GetRequestedRolesByRoleIds(List<long> roleIds)
        {
            var selectedRoles = new List<RoleViewModel>();
            foreach (var roleId in roleIds)
            {
                var role = _context.Roles.Select(x => new RoleViewModel { Id = x.Id, Name = x.Name }).FirstOrDefault(x => x.Id == roleId);
                selectedRoles.Add(role);
            }
            return selectedRoles;
        }

        public List<RoleViewModel> GetRequestedRolesByUserId(long userId)
        {
            var RequestedRoleIds = _context.UserCooperationRequests.Where(x=>x.UserId == userId).Select(x=>x.RoleId).ToList();
            var requestedRoles=new List<RoleViewModel>();
            foreach (var roleId in RequestedRoleIds)
            {
                var requstedRole= _context.Roles.Select(x=>new RoleViewModel 
                { Name=x.Name,
                    Id=x.Id
                }).FirstOrDefault(x=>x.Id==roleId);
                requestedRoles.Add(requstedRole);
            }

            return requestedRoles;
        }

        public List<UserRequestedForCooperationViewModel> GetUsersWithCooperationRequest()
        {
            return _context.Users.Include(x => x.UserCooperationRequests).Where(x => x.UserCooperationRequests.Count > 0).Select(x => new UserRequestedForCooperationViewModel
            {
                UserId = x.Id,
                CreationDate = x.CreationDate.ToFarsiFull(),
                FullName = x.FullName,
                IsRecognizedByAdmin=_context.UserRoles.Any(s=>s.UserId==x.Id),
            }).OrderByDescending(x => x.UserId).ToList();
        }

        public bool IsUserRequestedForCooperation(long userId)
        {
            return _context.UserCooperationRequests.Any(x => x.UserId == userId);
        }

        public bool  IsUserRequestForCooperationRecognizedByAdmin(long userId)
        {
            return _context.UserRoles.Any(x => x.UserId == userId);


        }
    }
}
