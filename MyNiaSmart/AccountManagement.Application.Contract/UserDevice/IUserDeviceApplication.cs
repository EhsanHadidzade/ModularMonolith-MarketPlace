using _0_Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserDevice
{
    public interface IUserDeviceApplication
    {
        OperationResult Create(CreateUserDevice command);
        OperationResult Edit(EditUserDevice command);
        EditUserDevice GetDetails(long id);
        OperationResult Remove(long id);
        List<UserDeviceViewModel> GetListByUserId(long userId);
    }
}
