﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.BusinessWallet
{
    public interface IBusinessWalletApplication
    {
        BusinessWalletViewModel GetWalletByUserId(long userId);
    }
}
