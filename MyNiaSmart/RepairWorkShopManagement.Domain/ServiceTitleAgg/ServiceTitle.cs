using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.ServiceTitleAgg
{
    public class ServiceTitle : BaseEntity
    {
        public string EngTitle { get; private set; }
        public string FarsiTitle { get; private set; }


        public ServiceTitle(string engTitle, string farsiTitle)
        {
            EngTitle = engTitle;
            FarsiTitle = farsiTitle;
        }

        public void Edit(string engTitle, string farsiTitle)
        {
            EngTitle = engTitle;
            FarsiTitle = farsiTitle;
        }

    }
}
