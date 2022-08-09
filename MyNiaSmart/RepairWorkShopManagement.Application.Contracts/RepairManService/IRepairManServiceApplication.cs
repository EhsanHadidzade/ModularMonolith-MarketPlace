using _0_Framework.Utilities;
using System.Collections.Generic;

namespace RepairWorkShopManagement.Application.Contracts.RepairManService
{
    public interface IRepairManServiceApplication
    {
        //ClientSide
        OperationResult Create(CreateRepairManService command);

        //ClientSide
        OperationResult Edit(EditRepairManService command);

        //ClientSide
        EditRepairManService GetDetails(long id);

        //To Get All In Admin Panel To Manage Them
        List<RepairManServiceViewModel> GetList();


        //To Get All OF Repair Man Services That are Selected By them to show in their panel
        List<RepairManServiceViewModel> GetListByRepairManPanelId(long repairManPanelId);

        //To Prepare Model for creatin new repairMan Service in their panel
        CreateRepairManService PrepareModelForCreationByRepairManPanelId(long repairManPanelId);

        //To Confirm New RepairMan services and edition
        OperationResult ConfirmByAdmin(long repairManServiceId);
    }
}
