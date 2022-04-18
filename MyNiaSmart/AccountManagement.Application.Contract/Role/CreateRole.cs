using AccountManagement.Application.Contract.RoleType;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.Role
{
    public class CreateRole
    {
        public string Name { get; set; }
        public long? RoleTypeId { get; set; }

        //To Fill List Of RoleTypes In Create Role Form
        public List<RoleTypeViewModel> RoleTypes { set; get; }
    }
}
