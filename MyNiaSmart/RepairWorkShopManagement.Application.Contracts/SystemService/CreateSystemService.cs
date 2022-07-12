using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.SystemService
{
    public class CreateSystemService
    {
        public string FarsiTitle { get;  set; }
        public string EngTitle { get;  set; }
        public long BaseFeePrice { get;  set; }
        public int SystemSharePercent { get;  set; }

        //FK
        public long ProductBrandId { get;  set; }
        public long ProductModelId { get;  set; }
        public long ProductTypeId { get;  set; }
        public long ProductUsageTypeId { get;  set; }
    }
}
