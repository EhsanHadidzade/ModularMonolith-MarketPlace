﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserCooperationRequest
{
    public class EditUserCooperationRequest:CreateUserCooperationRequest
    {
        public long Id { get; set; }
    }
}
