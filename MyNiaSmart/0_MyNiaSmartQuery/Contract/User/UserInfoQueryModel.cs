using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_MyNiaSmartQuery.Contract.User
{
    public class UserInfoQueryModel
    {
        public long Id { get; set; }
        public string FullName { get;  set; }
        public string MobileNumber { get;  set; }

        //optional
        public string Capital { get;  set; }
        public string City { get;  set; }
        public string Address { get;  set; }
        public string NationalCode { get;  set; }
        public string Birthday { get;  set; }
        public string ProfilePhoto { get;  set; }
        public string IntroductorFullname { get;  set; }
        public string IntroductorMobileNumber { get;  set; }

        //upaccount request
        public int UpAccountRequestCount { get; set; }
        public long UserUpAccountRequestId { get; set; }
        public string RejectionReason { get; set; }
        public bool IsConfirmedByAdmin { get; set; }
        public bool IsConfirmedByClient { get; set; }
    }
}
