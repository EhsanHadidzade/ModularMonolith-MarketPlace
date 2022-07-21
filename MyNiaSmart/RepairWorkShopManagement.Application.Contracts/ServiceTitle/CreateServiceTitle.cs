using _0_Framework.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.ServiceTitle
{
    public class CreateServiceTitle
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string EngTitle { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string FarsiTitle { get; set; }
    }
}
