using _0_Framework.Domain;
using RepairWorkShopManagement.Application.Contracts.RepairManService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.RepairManServiceAgg
{
    public interface IRepairManServiceRepository:IRepository<long,RepairManService>
    {
        //ClientSide
        EditRepairManService GetDetails(long id);

        //To Get All In Admin Panel To Manage Them
        List<RepairManServiceViewModel> GetList();

        //To Get All OF Repair Man Services That are Selected By them to show in their panel
        List<RepairManServiceViewModel> GetListByRepairManPanelId(long repairManPanelId);
    }
}
