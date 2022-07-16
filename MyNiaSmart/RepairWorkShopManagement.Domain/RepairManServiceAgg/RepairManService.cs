using _0_Framework.Domain;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.RepairManServiceAgg
{
    public class RepairManService:BaseEntity
    {
      
        public long Price { get; private set; }
        public int MarketerSharePercent { get; private set; }
        public int MarketerShareAmount { get; private set; }

        #region Default Values that are filled in RepairMan Panel Request
        public bool CanMarketerSee { get; private set; } //امکان بازار یابی به این سرویس شما، داده شود؟ 
        public int WarrantyTypeId { get; private set; }
        public int WarrantyAmount { get; private set; }
        #endregion

        public bool IsConfirmedByAdmin { get; private set; }
        public bool IsEditionConfirmedByAdmin { get; private set; }

        //relations
        public long RepairManPanelId { get; private set; }
        public long SystemServiceId { get; private set; }
        public RepairManPanel RepairManPanel { get;private set; }
        public SystemService SystemService { get;private set; }

        public RepairManService(long price, int marketerSharePercent, int marketerShareAmount,
            bool canMarketerSee, int warrantyTypeId, int warrantyAmount, long repairManPanelId,
            long systemServiceId)
        {
            Price = price;
            MarketerSharePercent = marketerSharePercent;
            MarketerShareAmount = marketerShareAmount;

            //Default Value
            CanMarketerSee = canMarketerSee;
            WarrantyTypeId = warrantyTypeId;
            WarrantyAmount = warrantyAmount;

            //FK
            RepairManPanelId = repairManPanelId;
            SystemServiceId = systemServiceId;

            IsConfirmedByAdmin = false;
            IsEditionConfirmedByAdmin=false;
        }

        public void Edit(long price, int marketerSharePercent, int marketerShareAmount,
            bool canMarketerSee, int warrantyTypeId, int warrantyAmount, long repairManPanelId,
            long systemServiceId)
        {
            Price = price;
            MarketerSharePercent = marketerSharePercent;
            MarketerShareAmount = marketerShareAmount;

            //Default Value
            CanMarketerSee = canMarketerSee;
            WarrantyTypeId = warrantyTypeId;
            WarrantyAmount = warrantyAmount;

            //FK
            RepairManPanelId = repairManPanelId;
            SystemServiceId = systemServiceId;

            IsConfirmedByAdmin = true;
            IsEditionConfirmedByAdmin = false;
        }

        public void ConfirmByAdmin()
        {
            IsConfirmedByAdmin=true;
            IsEditionConfirmedByAdmin = true;

        }
    }
}
