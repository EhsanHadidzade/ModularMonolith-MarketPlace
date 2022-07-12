using _0_Framework.Utilities;
using System.Collections.Generic;

namespace RepairWorkShopManagement.Application.Contracts.SystemService
{
    public interface ISystemServiceApplication
    {
        OperationResult Create(CreateSystemService command);
        OperationResult Edit(EditSystemService command);
        List<SystemServiceViewModel> GetList();
        EditSystemService GetDetails(long id);
    }
}
