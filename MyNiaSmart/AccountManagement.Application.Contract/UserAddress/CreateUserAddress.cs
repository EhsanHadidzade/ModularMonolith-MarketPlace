﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserAddress
{
    public class CreateUserAddress
    {
        public string Capital { get;  set; }
        public string City { get;  set; }
        public string Address { get;  set; }
        public string PlaqueNumber { get; set; }
        public string PostalCode { get;  set; }
        public string MobileNumber { get;  set; }
        public long UserId { get;  set; }
    }
}
