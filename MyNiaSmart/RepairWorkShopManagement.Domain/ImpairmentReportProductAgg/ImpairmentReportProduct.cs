using _0_Framework.Domain;
using RepairWorkShopManagement.Domain.UserImapairmentReportAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.ImpairmentReportProductAgg
{
    public class ImpairmentReportProduct:BaseEntity
    {
        public long UserImpairmentReportId { get; set; }
        public long ProductId { get; set; }

        //relations
        public UserImapairmentReport UserImapairmentReport { get; private set; }

        public ImpairmentReportProduct(long userImpairmentReportId, long productId)
        {
            UserImpairmentReportId = userImpairmentReportId;
            ProductId = productId;
        }
    }
}
