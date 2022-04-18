using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Role;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.RoleType
{
    public class CreateRoleType
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string RoleTypeName { get; set; }
    }
}
