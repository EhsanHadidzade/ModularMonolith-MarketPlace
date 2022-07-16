using _0_Framework.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.RepainManPanel
{
    public class CreateRepairManPanel
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string CommericalFullName { get;  set; } //نام تجاری

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Capital { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string City { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Address { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string MobileNumber { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string ShortResume { get;  set; } //رزمه مختصر 


        #region Default Fields that will display for creating each RepairMan Services
        public bool CanMarketerSee { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int WarrantyTypeId { get;  set; }

        [Range(1, int.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int WarrantyAmount { get;  set; }
        #endregion

        //relation
        public long UserId { get;  set; }

    }
}
