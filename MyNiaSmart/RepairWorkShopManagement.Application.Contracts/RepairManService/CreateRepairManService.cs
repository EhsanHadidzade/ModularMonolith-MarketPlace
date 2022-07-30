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
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long Price { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int MarketerSharePercent { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int MarketerShareAmount { get;  set; }


        #region Default Values that are filled in RepairMan Panel Request

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public bool CanMarketerSee { get;  set; } //امکان بازار یابی به این سرویس شما، داده شود؟ 

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int WarrantyTypeId { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int WarrantyAmount { get;  set; }
        #endregion


        //relations
        public long RepairManPanelId { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public List<long> SelectedSystemServiceIds { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string SystemServiceTitle { get; set; }
    }
}
