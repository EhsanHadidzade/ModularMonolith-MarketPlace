using _0_Framework.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.RepairManService
{
    public class CreateRepairManService
    {
        public long Price { get; set; }

        public int MarketerSharePercent { get; set; }

        public int MarketerShareAmount { get; set; }


        #region Default Values that are filled in RepairMan Panel Request

        public bool CanMarketerSee { get; set; } //امکان بازار یابی به این سرویس شما، داده شود؟ 

        public int WarrantyTypeId { get; set; }

        public int WarrantyAmount { get; set; }

        #endregion


        //relations
        public long RepairManPanelId { get; set; }

        public string SystemServiceTitle { get; set; }
        public List<long> SelectedSystemServiceIds { get; set; }

    }
}
