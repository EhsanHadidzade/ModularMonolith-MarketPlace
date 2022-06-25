using _0_Framework.Utilities;
using _0_MyNiaSmartQuery.Contract.User;
using AccountManagement.Domain.UPAccountRequestsAgg;
using AccountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUPAccountRequestRepository _upAccountRequestRepository;

        public UserQuery(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public UserInfoQueryModel GetUserInfo(long userId)
        {
            //var IsUpAccountRequest = _accountContext.UpAccountRequests.Count(x => x.UserId == userId);
            var userRequest = _accountContext.UpAccountRequests.Select(x => new
            {
                x.Id,
                x.UserId,
                x.IsRequestConfirmedByAdmin,
                x.IsRequestConfirmedByClient
            }).FirstOrDefault(x => x.UserId == userId);

            var userInfo = _accountContext.Users.Select(x => new UserInfoQueryModel
            {
                Id = x.Id,
                FullName = x.FullName,
                MobileNumber = x.MobileNumber,
                NationalCode = x.NationalCode,
                //Capital = x.Capital,
                //City = x.City,
                //Address = x.Address,
                Birthday = x.Birthday.ToFarsi(),
                ProfilePhoto = x.ProfilePhoto,
                IntroductorFullname = x.IntroductorFullname,
                IntroductorMobileNumber = x.IntroductorMobileNumber,
                //UpAccountRequestCount=IsUpAccountRequest,
                //UserUpAccountRequestId=x.UpAccountRequest.Id,
                //IsConfirmedByAdmin=x.UpAccountRequest.IsRequestConfirmedByAdmin,
                //IsConfirmedByClient=x.UpAccountRequest.IsRequestConfirmedByClient
            }).FirstOrDefault(x => x.Id == userId);

            if (userRequest != null)
            {
                //    userInfo.UpAccountRequestCount = IsUpAccountRequest;
                userInfo.UserUpAccountRequestId = userRequest.Id;
                userInfo.IsConfirmedByAdmin = userRequest.IsRequestConfirmedByAdmin;
                userInfo.IsConfirmedByClient = userRequest.IsRequestConfirmedByClient;
            }

            return userInfo;

        }
    }
}
