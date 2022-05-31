using _0_Framework.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerPanel
{
    public class CreateSellerPanel
    {
        [Required(ErrorMessage=ValidationMessage.IsRequired)]
        public string Address { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MinLength(11,ErrorMessage ="شماره معتبر نیست")]
        public string SellerMobileNumber { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Capital { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string City { get; set; }


        #region Default Values
        [Range(1, 250, ErrorMessage = "مقدار قابل قبول نیست")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int DeliveryDurationForCity { get; set; }

        [Range(1, 250, ErrorMessage = "مقدار قابل قبول نیست")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int DeliveryDurationForCapital { get; set; }

        [Range(1, 250, ErrorMessage = "مقدار قابل قبول نیست")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int DeliveryDurationForOther { get; set; }

        [Range(1, 5, ErrorMessage = "مقدار قابل قبول نیست")]
        public int WarrantyTypeId { get; set; }

        [Range(1, 250, ErrorMessage = "مقدار قابل قبول نیست")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int WarrantyAmount { get; set; }

        [Range(1, 4, ErrorMessage = "مقدار قابل قبول نیست")] // 1=sellToNormalPeople 2=SellToServiceMan 3=BothCanSee
        public int BuyersCategory { get; set; }

        public bool CanMarketerSee { get; set; }
        #endregion
        public bool IsUserLegal { get;  set; }

        //IllegulUser
        [Required(ErrorMessage = ValidationMessage.IsRequired)] 
        public string StoreName { get;  set; }



        //legalUser
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string CompanyName { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string CompanyRegistrationCode { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string CompanyEconomicCode { get;  set; }

        //relations
        public long UserId { get;  set; }
    }
}
