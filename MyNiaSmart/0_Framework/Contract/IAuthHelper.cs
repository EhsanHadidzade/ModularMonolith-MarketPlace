using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Contract
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void Signin(AuthViewModel account);
        AuthViewModel CurrentAccountInfo();
    }
}
