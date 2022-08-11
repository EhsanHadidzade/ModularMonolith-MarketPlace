using _0_Framework.Domain;
using RepairWorkShopManagement.Domain.ImpairmentReportProductAgg;
using RepairWorkShopManagement.Domain.ImpairmentReportServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.UserImapairmentReportAgg
{
    public class UserImapairmentReport : BaseEntity
    {
        public long UserId { get; private set; }
        public long UserDeviceId { get; private set; }
        //public long SystemServiceId { get;private set; }
        public string Description { get; private set; }

        public bool IsHandlingByRepairMan { get; private set; }
        public long RepairManPanelId { get; private set; }

        public bool IsDone { get; set; }

        //relation
        public List<ImpairmentReportService> ImpairmentReportServices { get;private set; }
        public List<ImpairmentReportProduct> ImpairmentReportProducts { get;private set; }

        public UserImapairmentReport(long userId, long userDeviceId, string description)
        {
            UserId = userId;
            UserDeviceId = userDeviceId;
            Description = description;

            IsHandlingByRepairMan = false;
            IsDone=false;

            ImpairmentReportServices = new List<ImpairmentReportService>();
            ImpairmentReportProducts= new List<ImpairmentReportProduct>();

        }

        public void Edit(long userDeviceId, string description)
        {
            UserDeviceId = userDeviceId;
            Description = description;
        }

        public void AcceptedByRepairMan(long repairManPanelId)
        {
            IsHandlingByRepairMan=true;
            RepairManPanelId = repairManPanelId;
        }

        public void SetAsDone()
        {
            IsDone=true;
        }
    }
}
