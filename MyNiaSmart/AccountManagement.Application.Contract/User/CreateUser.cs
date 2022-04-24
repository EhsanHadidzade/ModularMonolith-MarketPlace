using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.User
{
    public class CreateUser
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string FullName { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string MobileNumber { get;  set; }

        //optional 
        public string Capital { get;  set; }
        public string City { get;  set; }
        public string Address { get;  set; }
        public string NationalCode { get;  set; }
        public string Birthday { get;  set; }
        public IFormFile ProfilePhoto { get;  set; }
        public string IntroductorFullname { get;  set; }
        public string IntroductorMobileNumber { get;  set; }

        public long Experience { get; set; }
        public int Grade { get; set; }

        public List<RoleViewModel> Roles { get; set; }
    }
}
