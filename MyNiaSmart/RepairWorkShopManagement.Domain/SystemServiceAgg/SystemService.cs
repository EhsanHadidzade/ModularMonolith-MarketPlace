using _0_Framework.Domain;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.SystemServiceAgg
{
    public class SystemService : BaseEntity
    {

        public long BaseFeePrice { get; private set; }
        public int SystemSharePercent { get; private set; }
        public int WarrantyTypeId { get; private set; }
        public int WarrantyAmount { get; private set; }
        public string Description { get; private set; }
        public string Duration { get; private set; }

        //FK
        public long ProductBrandId { get; private set; }
        public long ProductModelId { get; private set; }
        public long ProductTypeId { get; private set; }
        public long ProductUsageTypeId { get; private set; }
        public long ServiceTitleId { get; private set; }

        //relations
        public List<RepairManService> RepairManServices { get; private set; }

        public SystemService(long baseFeePrice, int systemSharePercent, int warrantyTypeId,
            int warrantyAmount,string description,string duration, long productBrandId, long productModelId, long productTypeId,
            long productUsageTypeId, long serviceTitleId)
        {
            BaseFeePrice = baseFeePrice;
            SystemSharePercent = systemSharePercent;
            WarrantyTypeId = warrantyTypeId;
            WarrantyAmount = warrantyAmount;
            Description = description;
            Duration = duration;

            //FK
            ProductBrandId = productBrandId;
            ProductModelId = productModelId;
            ProductTypeId = productTypeId;
            ProductUsageTypeId = productUsageTypeId;
            ServiceTitleId = serviceTitleId;

            RepairManServices = new List<RepairManService>();
        }

        public void Edit(long baseFeePrice, int systemSharePercent, int warrantyTypeId,
            int warrantyAmount,string description,string duration,long productBrandId, long productModelId, long productTypeId,
            long productUsageTypeId, long serviceTitleId)
        {
            BaseFeePrice = baseFeePrice;
            SystemSharePercent = systemSharePercent;
            WarrantyTypeId = warrantyTypeId;
            WarrantyAmount = warrantyAmount;
            Description = description;
            Duration = duration;

            //FK
            ProductBrandId = productBrandId;
            ProductModelId = productModelId;
            ProductTypeId = productTypeId;
            ProductUsageTypeId = productUsageTypeId;
            ServiceTitleId = serviceTitleId;
        }
    }
}
