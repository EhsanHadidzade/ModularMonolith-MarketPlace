using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UserDeviceAgg
{
    public class UserDevice:BaseEntity
    {
        public long UserId { get; private set; }
        public long ProductId { get; private set; }

        public UserDevice(long userId, long productId)
        {
            UserId = userId;
            ProductId = productId;
        }

        public void Edit(long productId)
        {
            ProductId = productId;
        }
    }
}
