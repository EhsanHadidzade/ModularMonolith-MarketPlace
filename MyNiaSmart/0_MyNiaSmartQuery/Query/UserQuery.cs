using _0_Framework.Utilities;
using _0_MyNiaSmartQuery.Contract.User;
using AccountManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_MyNiaSmartQuery.Query
{
    public class UserQuery : IUserQuery
    {
        private readonly AccountContext _accountContext;

        public UserQuery(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public UserInfoQueryModel GetUserInfo(long userId)
        {
            return _accountContext.Users.Select(x => new UserInfoQueryModel
            {
                Id = x.Id,
                FullName = x.FullName,
                MobileNumber=x.MobileNumber,
                NationalCode=x.NationalCode,
                Capital=x.Capital,
                City=x.City,
                Address = x.Address,
                Birthday=x.Birthday.ToFarsi(),
                ProfilePhoto=x.ProfilePhoto,
                IntroductorFullname=x.IntroductorFullname,
                IntroductorMobileNumber=x.IntroductorMobileNumber
            }).FirstOrDefault(x => x.Id == userId);
        }
    }
}
