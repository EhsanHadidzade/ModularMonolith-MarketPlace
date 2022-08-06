using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.UserImapairmentReport
{
    public class CreateUserImpairmentReport
    {
        public long UserId { get;  set; }
        public long UserDeviceId { get;  set; }
        public long SystemServiceId { get; set; }
        public string Description { get;  set; }
    }
}
