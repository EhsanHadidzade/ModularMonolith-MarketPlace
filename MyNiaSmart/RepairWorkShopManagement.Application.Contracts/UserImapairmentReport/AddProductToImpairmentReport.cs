using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.UserImapairmentReport
{
    public class AddProductToImpairmentReport
    {
        public long ImpairmentReportId { get; set; }
        public List<long> ProductIds { get; set; }
    }
}
