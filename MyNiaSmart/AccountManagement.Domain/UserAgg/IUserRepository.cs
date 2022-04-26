using _0_Framework.Domain;
using AccountManagement.Application.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UserAgg
{
    public interface IUserRepository:IRepository<long,User>
    {
        User GetUserByMobileNumber(string mobileNumber);
        EditUser GetDetails(long id);
        List<UserViewModel> GetList();
    }
}
