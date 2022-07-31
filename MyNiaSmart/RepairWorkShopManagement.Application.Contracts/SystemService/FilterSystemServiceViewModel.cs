using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.SystemService
{
    public class FilterSystemServiceViewModel
    {
        public long BrandId { get; set; }
        public long ModelId { get; set; }
        public long TypeId { get; set; }
        public long usageTypeId { get; set; }

    }
}
