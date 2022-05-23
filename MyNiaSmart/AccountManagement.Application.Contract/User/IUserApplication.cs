using _0_Framework.Utilities;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.User
{
    public interface IUserApplication
    {
        OperationResult Create(CreateUser command);
        OperationResult Edit(EditUser command);
        OperationResult RegisterOrLogin(RegisterOrLoginUser command);
        List<UserViewModel> GetList();
        EditUser GetDetails(long id);
        OperationResult CheckVerificationCode(VerificationCode command);
        void LogOut();

        //To check if a user is AdminOrNot
        bool IsUserAdmin(long userId);


    }
}
