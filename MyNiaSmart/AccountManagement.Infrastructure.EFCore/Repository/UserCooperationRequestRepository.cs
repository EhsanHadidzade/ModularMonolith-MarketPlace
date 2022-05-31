using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Personality;
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

        public List<UserCooperationRequest> GetAllUserRequestedPersonalitiesByUserId(long userId)
        {
            return _context.UserCooperationRequests.Where(x => x.UserId == userId).ToList();
        }


        public List<PersonalityViewModel> GetRequestedPersonalitiesByPersonalityIds(List<long> personalityIds)
        {
            var SelectedPersonalities = new List<PersonalityViewModel>();
            foreach (var personalityId in personalityIds)
            {
                var personality = _context.Personalities.Select(x => new PersonalityViewModel { Id = x.Id, Title = x.Title }).FirstOrDefault(x => x.Id == personalityId);
                SelectedPersonalities.Add(personality);
            }
            return SelectedPersonalities;
        }

        public List<PersonalityViewModel> GetRequestedPersonalitiesByUserId(long userId)
        {
            var RequestedRoleIds = _context.UserCooperationRequests.Where(x => x.UserId == userId).Select(x => x.PersonalityId).ToList();
            var requestedPersonalities = new List<PersonalityViewModel>();
            foreach (var roleId in RequestedRoleIds)
            {
                var requstedPersonality = _context.Personalities.Include(x=>x.PersonalityType).Select(x => new PersonalityViewModel
                {
                    Id = x.Id,
                    Title=x.Title,
                    PersonalityTypeId=x.PersonalityTypeId,
                    PersonalityTypeTitle=x.PersonalityType.Title
                }).FirstOrDefault(x => x.Id == roleId);
                requestedPersonalities.Add(requstedPersonality);
            }

            return requestedPersonalities;
        }

        public List<UserRequestedForCooperationViewModel> GetUsersWithCooperationRequest()
        {
            return _context.Users.Include(x => x.UserCooperationRequests).Where(x => x.UserCooperationRequests.Count > 0).Select(x => new UserRequestedForCooperationViewModel
            {
                UserId = x.Id,
                CreationDate = x.CreationDate.ToFarsiFull(),
                FullName = x.FullName,
                IsRecognizedByAdmin = _context.UserPersonalities.Any(s => s.UserId == x.Id),
            }).OrderByDescending(x => x.UserId).ToList();
        }

        public bool IsUserRequestedForCooperation(long userId)
        {
            return _context.UserCooperationRequests.Any(x => x.UserId == userId);
        }

        public bool IsUserRequestForCooperationRecognizedByAdmin(long userId)
        {
            return _context.UserPersonalities.Any(x => x.UserId == userId);


        }
    }
}
