using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UpAccountRequest
{
    public class UpAccountRequestViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public long UserId { get; set; }
        public string Capital { get; set; }
        public string City { get; set; }
        public bool IsConfirmedByAdmin { get; set; }
        public bool IsConfirmedByClient { get; set; }

    }
}
