using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserCooperationRequest
{
    public class UserRequestedForCooperationViewModel
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string CreationDate { get; set; }
        public bool IsRecognizedByAdmin { get; set; }

    }
}
