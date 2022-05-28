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
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string StoreName { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Address { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string StoreMobileNumber { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)] //1=sellToNormalPeople 2=SellToServiceMan 3=BothCanSee
        public int BuyersCategory { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public bool CanMarketerSee { get;  set; }

        //relations
        public long UserId { get;  set; }
    }
}
