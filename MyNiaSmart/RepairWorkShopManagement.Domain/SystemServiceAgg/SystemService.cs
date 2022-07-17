using _0_Framework.Domain;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.SystemServiceAgg
{
    public class SystemService:BaseEntity
    {
        public string FarsiTitle { get; private set; }
        public string EngTitle { get; private set; }
        public long BaseFeePrice { get;private set; }
        public int SystemSharePercent { get;private set; }
        public int WarrantyTypeId { get; private set; }
        public int WarrantyAmount { get; private set; }

        //FK
        public long ProductBrandId { get; private set; }
        public long ProductModelId { get; private set; }
        public long ProductTypeId { get; private set; }
        public long ProductUsageTypeId { get; private set; }

        //relations
        public List<RepairManService> RepairManServices { get;private set; }

        public SystemService(string farsiTitle, string engTitle, long baseFeePrice, int systemSharePercent,
           int warrantyTypeId ,int warrantyAmount, long productBrandId, long productModelId, long productTypeId, long productUsageTypeId)
        {
            FarsiTitle = farsiTitle;
            EngTitle = engTitle;
            BaseFeePrice = baseFeePrice;
            SystemSharePercent = systemSharePercent;

            //FK
            ProductBrandId = productBrandId;
            ProductModelId = productModelId;
            ProductTypeId = productTypeId;
            ProductUsageTypeId = productUsageTypeId;
            WarrantyTypeId = warrantyTypeId;
            WarrantyAmount = warrantyAmount;

            //relation
            RepairManServices= new List<RepairManService>();
        }

        public void Edit(string farsiTitle, string engTitle, long baseFeePrice, int systemSharePercent,
              int warrantyTypeId, int warrantyAmount, long productBrandId, long productModelId, long productTypeId, long productUsageTypeId)
        {
            FarsiTitle = farsiTitle;
            EngTitle = engTitle;
            BaseFeePrice = baseFeePrice;
            SystemSharePercent = systemSharePercent;
            WarrantyTypeId = warrantyTypeId;
            WarrantyAmount = warrantyAmount;

            //FK
            ProductBrandId = productBrandId;
            ProductModelId = productModelId;
            ProductTypeId = productTypeId;
            ProductUsageTypeId = productUsageTypeId;
        }
    }
}
