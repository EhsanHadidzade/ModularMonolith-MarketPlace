using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserPersonalityRequest
{
    public class CreateUserPersonalityRequestForSellerPanel
    {
        public long UserId { get; set; }
        public List<long> RequestedPersonalityIds { get; set; }
    }
}
