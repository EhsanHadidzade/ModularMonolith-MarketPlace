using _0_Framework.Domain;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.SystemServiceAgg
{
    public interface ISystemServiceRepository:IRepository<long,SystemService>
    {
        List<SystemServiceViewModel> GetList();
        EditSystemService GetDetails(long id);

        //To Filter List In RepairMan Panel While they are selecting them in their panel
        List<SystemServiceViewModel> GetFilteredListByCategoryIds(FilterSystemServiceViewModel command);
        

    }
}
