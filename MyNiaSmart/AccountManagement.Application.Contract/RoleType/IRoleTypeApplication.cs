using _0_Framework.Utilities;
using System;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.RoleType
{
    public interface IRoleTypeApplication
    {
        OperationResult Create(CreateRoleType command);
        OperationResult Edit(EditRoleType command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditRoleType getDetails(long id);

        
        List<RoleTypeViewModel> GetList();

        //To Use in editUserRoleView as model
        Tuple<List<RoleTypeViewModel>,List<long>,long> GetAllRolesWithSelectedRolesOfOneUserByUserId(long userId);
    }
}
