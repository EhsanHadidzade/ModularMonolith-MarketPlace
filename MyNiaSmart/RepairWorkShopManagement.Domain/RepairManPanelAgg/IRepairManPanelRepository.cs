using _0_Framework.Domain;
using RepairWorkShopManagement.Application.Contracts.RepainManPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.RepairManPanelAgg
{
    public interface IRepairManPanelRepository : IRepository<long, RepairManPanel>
    {
        List<RepairManPanelViewModel> GetList();
        EditRepairManPanel GetDetails(long id);
        long GetRepairManPanelIdByUserId(long userId);

        //ToDisable Button In UserPanel For Creation RepairMan Panel
        bool HasUserRequestedForRepairManPanel(long userId);
    }
}
