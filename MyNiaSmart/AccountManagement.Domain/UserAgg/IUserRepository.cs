using _0_Framework.Domain;
using AccountManagement.Application.Contract.User;
using System.Collections.Generic;

namespace AccountManagement.Domain.UserAgg
{
    public interface IUserRepository:IRepository<long,User>
    {
        User GetUserByMobileNumber(string mobileNumber);
        EditUser GetDetails(long id);
        List<UserViewModel> GetList();
        

        //to use for auto fill upAccountRequest Form
        UserViewModel GetSomeInfoByUserId(long userId); 
        //to use in authentication result
        User GetUserByActiveCode(string activeCode);

        //To check if a user is AdminOrNot
        bool IsUserAdmin(long userId);

        string GetFullNameByUserId(long userId);
        int GetGradeByUserId(long userId);

     

        
    }
}
