using _0_Framework.Utilities;
using System.Collections.Generic;

namespace RepairWorkShopManagement.Application.Contracts.ServiceTitle
{
    public interface IServiceTitleApplication
    {
        OperationResult Create(CreateServiceTitle command);
        OperationResult Edit(EditServiceTitle command);
        List<ServiceTitleViewModel> GetList();
        EditServiceTitle GetDetails(long id);
    }
}
