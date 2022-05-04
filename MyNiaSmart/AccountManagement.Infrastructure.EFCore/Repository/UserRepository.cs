using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.User;
using AccountManagement.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
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
                FullName = x.FullName,
                MobileNumber = x.MobileNumber,
                NationalCode = x.NationalCode,
                Address = x.Address,
                Birthday = x.Birthday.ToFarsi(),
                Capital = x.Capital,
                City = x.City,
                IntroductorFullname = x.IntroductorFullname,
                IntroductorMobileNumber = x.IntroductorMobileNumber,
                Grade = x.Grade,
                Experience=x.Experience,
                ProfilePicAddress = x.ProfilePhoto
               
            }).FirstOrDefault(x=>x.Id == id);
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(x=>x.ActiveCode == activeCode);
        }

        public User GetUserByMobileNumber(string mobileNumber)
        {
            return _context.Users.FirstOrDefault(x=>x.MobileNumber == mobileNumber);
        }

        List<UserViewModel> IUserRepository.GetList()
        {
            return _context.Users.Select(x => new UserViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Grade=x.Grade,
                ProfilePhoto=x.ProfilePhoto,
                CreationDate=x.CreationDate.ToFarsi()
            }).ToList();
        }
    }
}
