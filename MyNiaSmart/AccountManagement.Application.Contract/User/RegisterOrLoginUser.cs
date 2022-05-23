using _0_Framework.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.User
{
    public class RegisterOrLoginUser
    {

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MinLength(11, ErrorMessage = "شماره همراه معتبر نیست")]
        public string MobileNumber { get; set; }

        public string FullName { get; set; }

    }
}
