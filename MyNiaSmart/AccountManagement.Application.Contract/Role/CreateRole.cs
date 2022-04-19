using _0_Framework.Utilities;
using AccountManagement.Application.Contract.RoleType;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contract.Role
{
    public class CreateRole
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long? RoleTypeId { get; set; }

        //To Fill List Of RoleTypes In Create Role Form
        public List<RoleTypeViewModel> RoleTypes { set; get; }
    }
}
