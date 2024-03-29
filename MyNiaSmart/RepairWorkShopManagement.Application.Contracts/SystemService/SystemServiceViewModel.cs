﻿namespace RepairWorkShopManagement.Application.Contracts.SystemService
{
    public class SystemServiceViewModel
    {
        public long Id { get; set; }
        public long BaseFeePrice { get; set; }
        public int SystemSharePercent { get; set; }
        public string Duration { get; set; }
        public int WarrantyTypeId { get; set; }
        public int WarrantyAmount { get; set; }


        //FK
        public long ProductBrandId { get; set; }
        public long ProductModelId { get; set; }
        public long ProductTypeId { get; set; }
        public long ProductUsageTypeId { get; set; }
        public long ServiceTitleId { get; set; }

        //FK EngTitles
        public string BrandEngTitle { get; set; }
        public string ModelEngTitle { get; set; }
        public string TypeEngTitle { get; set; }
        public string UsageTypeEngTitle { get; set; }
        public string SystemServiceEngTitle { get; set; }

        //FK FarsiTitles
        public string BrandFarsiTitle { get; set; }
        public string ModelFarsiTitle { get; set; }
        public string TypeFarsiTitle { get; set; }
        public string UsageTypeFarsiTitle { get; set; }
        public string SystemServiceFarsiTitle { get; set; }

    }
}
