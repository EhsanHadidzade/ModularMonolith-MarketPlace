using _0_Framework.Utilities;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.UserAddress
{
    public interface IUserAddressApplication
    {
        OperationResult Create(CreateUserAddress command);
        List<UserAddressViewModel> GetListByUserId(long userId);
        EditUserAddress GetDetails(long id);
        OperationResult Edit(EditUserAddress command);
        OperationResult Remove(long userAddressId);
        

    }
}
