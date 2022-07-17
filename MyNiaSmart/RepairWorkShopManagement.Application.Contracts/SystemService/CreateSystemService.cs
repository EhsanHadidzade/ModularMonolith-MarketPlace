using _0_Framework.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.SystemService
{
    public class CreateSystemService
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string FarsiTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string EngTitle { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long BaseFeePrice { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int SystemSharePercent { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int WarrantyTypeId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int WarrantyAmount { get; set; }

        //FK
        [Range(1,long.MaxValue,ErrorMessage =ValidationMessage.IsRequired)]
        public long ProductBrandId { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductModelId { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductTypeId { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductUsageTypeId { get;  set; }
    }
}
