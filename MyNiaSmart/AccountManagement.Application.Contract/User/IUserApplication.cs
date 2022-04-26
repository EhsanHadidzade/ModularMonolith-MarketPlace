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

    }
}
