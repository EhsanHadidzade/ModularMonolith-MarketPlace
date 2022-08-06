using _0_Framework.Domain;
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
        public long SystemServiceId { get;private set; }
        public string Description { get; private set; }


        public bool IsHandlingByRepairMan { get; private set; }
        public long RepairManPanelId { get; private set; }

        public bool IsDone { get; set; }

        public UserImapairmentReport(long userId, long userDeviceId, long systemServiceId, string description)
        {
            UserId = userId;
            UserDeviceId = userDeviceId;
            SystemServiceId = systemServiceId;
            Description = description;

            IsHandlingByRepairMan = false;
            IsDone=false;
        }

        public void Edit(long userDeviceId, long systemServiceId, string description)
        {
            UserDeviceId = userDeviceId;
            SystemServiceId = systemServiceId;
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
