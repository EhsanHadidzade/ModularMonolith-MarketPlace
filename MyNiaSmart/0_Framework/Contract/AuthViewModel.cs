using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Contract
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        //public long RoleId { get; set; }
        //public string Role { get; set; }
        public string Fullname { get; set; }
        //public string Username { get; set; }
        public string Mobile { get; set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(long id, string fullname, string mobile)
        {
            Id = id;
            Fullname = fullname;
            Mobile = mobile;
        }
    }
}
