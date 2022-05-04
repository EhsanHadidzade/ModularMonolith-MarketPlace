using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_MyNiaSmartQuery.Contract.User
{
    public interface IUserQuery
    {
        //To Show UserInfo in their userProfile
        UserInfoQueryModel GetUserInfo(long userId);
    }
}
