using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UpAccountRequest
{
    public class UpAccountRequestStatusVIewModel
    {
        public long UserId { get; set; }
        public bool IsConfirmedByAdmin { get; set; }
      
    }
}
