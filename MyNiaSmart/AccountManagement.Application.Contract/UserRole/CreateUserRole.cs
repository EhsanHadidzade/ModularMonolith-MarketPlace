using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserRole
{
    public class CreateUserRole
    {
        public long UserId { get; set; }
        public List<int> SelectedRoleIds { get; set; }
    }
}
