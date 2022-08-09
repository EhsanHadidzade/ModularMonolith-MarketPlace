using _0_Framework.Domain;
using RepairWorkShopManagement.Application.Contracts.UserImapairmentReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.UserImapairmentReportAgg
{
    public interface IUserImapairmentReportRepository : IRepository<long, UserImapairmentReport>
    {
        //Using For User To See their ImpairmentReports With Status
        //List<UserImapairmentReport> GetAllByUserId(long userId);

        //using For RepairMan to See the ImpairmentReports That he accepted
        List<UserImapairmentReport> GetAllByRepairManPanelId(int repairManPanelId);

        //TO Show  list of user current impairmentReports that are processing
        List<UserImapairmentReport> GetCurrentUserImpairmentReports(long userId);
    }
}
