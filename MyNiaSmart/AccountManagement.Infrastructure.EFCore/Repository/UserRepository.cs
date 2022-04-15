using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.User;
using AccountManagement.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class UserRepository : BaseRepository<long, User>, IUserRepository
    {
        private readonly AccountContext _context;

        public UserRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public EditUser GetDetails(long id)
        {
            return _context.Users.Select(x => new EditUser
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                MobileNumber = x.MobileNumber,
                NationalCode = x.NationalCode,
                Address = x.Address,
                Birthday = x.Birthday.ToFarsi(),
                Capital = x.Capital,
                City = x.City,
                IntroductorFullname = x.IntroductorFullname,
                IntroductorMobileNumber = x.IntroductorMobileNumber,
            }).FirstOrDefault(x=>x.Id == id);
        }

        List<UserViewModel> IUserRepository.GetList()
        {
            return _context.Users.Select(x => new UserViewModel
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Role = "مشتری"
            }).ToList();
        }
    }
}
