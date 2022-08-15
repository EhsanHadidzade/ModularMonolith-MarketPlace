using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Utilities
{
    public class GenerateUniqueCode
    {
        public static string GenerateRandomNo()
        {
            var  _random = new Random();
            return _random.Next(0, 99999).ToString("D5");
        }

     
    }
}
