using _0_Framework.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserAddress
{
    public class CreateUserAddress
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Capital { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string City { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Address { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PlaqueNumber { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PostalCode { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string MobileNumber { get;  set; }

        [Range(1,long.MaxValue,ErrorMessage =ValidationMessage.IsRequired)]
        public long UserId { get;  set; }
    }
}
