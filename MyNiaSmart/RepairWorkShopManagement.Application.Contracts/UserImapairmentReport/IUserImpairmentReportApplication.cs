using _0_Framework.Utilities;
using System.Collections.Generic;

namespace RepairWorkShopManagement.Application.Contracts.UserImapairmentReport
{
    public interface IUserImpairmentReportApplication
    {

        OperationResult Create(CreateUserImpairmentReport command);
        OperationResult Edit(EditUserImpairmentReport command);
        OperationResult AddProduct(AddProductToImpairmentReport command);
        OperationResult ChooseRepairMan(long repairmanPanelId, long userImpairmentReportId);

        EditUserImpairmentReport GetDetails(long id);

        List<long> GetSelectedProductIds(long userImpairmentReportId);


        //OperationResult AcceptToHandleByRepairManPanelId(long repairManPanelId);



        ////using For RepairMan to See the ImpairmentReports That he accepted
        //List<UserImpairmentReportViewModel> GetAllByRepairManPanelId(int repairManPanelId);

        //TO Show  list of user current impairmentReports that are processing
        List<UserImpairmentReportViewModel> GetCurrentUserImpairmentReports(long userId);


        //using in repairmanPanel To See if some one choosed him to handle their ImpairmentReport
        List<UserImpairmentReportViewModel> GetRepairManRelatedReports();

        //to show list of user Done ImpairmentReport 
        List<UserImpairmentReportViewModel> GetDoneImpairmentReports(long userId);

        //To Get List That Specific Repairman has Done 
        List<UserImpairmentReportViewModel> GetRepairmanDoneImpairment(long userId);
    }
}
