using _0_Framework.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerProduct
{
    public class CreateSellerProduct
    {
        public long SellerPanelId { get;  set; }

        [Range(1,long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string ProductTitle { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long Price { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Description { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int MarketerSharePercent { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long MarketerShareAmount { get; set; }

        #region Default Values that are filled in c

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int DeliveryDurationForCity { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int DeliveryDurationForCapital { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int DeliveryDurationForOther { get;  set; }

        public bool CanMarketerSee { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]

        public int BuyersCategory { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int WarrantyTypeId { get;  set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int WarrantyAmount { get;  set; }


        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public List<long> SelectedMediaIds { get; set; }

        #endregion
    }
}
