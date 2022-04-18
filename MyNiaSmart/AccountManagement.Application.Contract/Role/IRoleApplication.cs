using _0_Framework.Utilities;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole command);
        OperationResult Edit(EditRole command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditRole getDetails(long id);
        List<RoleViewModel> GetList();
    }
}
