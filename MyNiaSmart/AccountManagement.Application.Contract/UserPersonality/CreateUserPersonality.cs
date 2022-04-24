using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserPersonality
{
    public class CreateUserPersonality
    {
        public long UserId { get; set; }
        public List<long> SelectedPersonalityIds { get; set; }
    }
}
