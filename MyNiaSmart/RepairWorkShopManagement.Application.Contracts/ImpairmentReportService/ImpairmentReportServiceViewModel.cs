using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.ImpairmentReportService
{
    public class ImpairmentReportServiceViewModel
    {
        public long Id { get; set; }
        public string SystemServiceTitle { get; set; }
        public string ServiceBrandTitle { get; set; }
        public string ServiceModelTitle { get; set; }
        public string ServiceTypeTitle { get; set; }
        public string ServiceUsageTypeTitle { get; set; }

    }
}
