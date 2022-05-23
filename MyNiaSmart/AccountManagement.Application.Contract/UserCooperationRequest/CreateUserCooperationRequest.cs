using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserCooperationRequest
{
    public class CreateUserCooperationRequest
    {
        public long UserId { get; set; }
        public List<long> SelectedRoleIds { get; set; }
    }
}
