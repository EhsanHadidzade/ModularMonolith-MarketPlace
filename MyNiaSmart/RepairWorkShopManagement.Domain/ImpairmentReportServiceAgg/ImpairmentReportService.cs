using _0_Framework.Domain;
using RepairWorkShopManagement.Domain.UserImapairmentReportAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.ImpairmentReportServiceAgg
{
    public class ImpairmentReportService:BaseEntity
    {
        public long UserImpairmentReportId { get;private set; }
        public long SystemServiceId { get;private set; }

        //Relation
        public UserImapairmentReport UserImapairmentReport { get;private set; }

        public ImpairmentReportService(long userImpairmentReportId, long systemServiceId)
        {
            UserImpairmentReportId = userImpairmentReportId;
            SystemServiceId = systemServiceId;
        }
    }
}
