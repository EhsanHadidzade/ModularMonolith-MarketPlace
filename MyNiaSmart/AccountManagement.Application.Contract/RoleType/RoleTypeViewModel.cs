using AccountManagement.Application.Contract.Role;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.RoleType
{
    public class RoleTypeViewModel
    {
        public long Id { get; set; }
        public string RoleTypeName { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
        public List<RoleViewModel> Roles { get; set; }  
    }
}
