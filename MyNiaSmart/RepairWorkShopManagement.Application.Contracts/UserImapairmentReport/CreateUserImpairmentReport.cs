using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.UserImapairmentReport
{
    public class CreateUserImpairmentReport
    {
        public long UserId { get;  set; }
        public long UserDeviceId { get;  set; }
        public string Description { get;  set; }

        public string UserDeviceTitle { get; set; }
        public List<long> SelectedSystemServiceIds { get; set; }


    }
}
