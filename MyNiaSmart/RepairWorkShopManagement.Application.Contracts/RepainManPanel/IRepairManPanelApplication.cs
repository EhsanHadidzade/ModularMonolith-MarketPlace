using _0_Framework.Utilities;
using System.Collections.Generic;

namespace RepairWorkShopManagement.Application.Contracts.RepainManPanel
{
    public interface IRepairManPanelApplication
    {
        //AdminSide
        List<RepairManPanelViewModel> GetList();
        EditRepairManPanel GetDetails(long id);
        OperationResult ConfirmByAdmin(long repairManPanelId);

        //ClientSide
        OperationResult Create(CreateRepairManPanel command);
        long GetRepairManPanelIdByUserId(long userId);

        //ToDisable Button In UserPanel For Creation RepairMan Panel
        bool HasUserRequestedForRepairManPanel(long userId);

        //to Show Or Hide RepairManPanelPanelButton in clientSideMenu for Adding  System Services and see Chartreports
        bool HasUserRepairManPanelConfirmedByAdmin(long userId);   

    }
}
