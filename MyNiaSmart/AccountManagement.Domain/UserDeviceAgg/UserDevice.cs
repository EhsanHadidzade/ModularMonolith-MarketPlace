using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UserDeviceAgg
{
    public class UserDevice : BaseEntity
    {
        public long UserId { get; private set; }
        public long ProductId { get; private set; }

        //Map
        public decimal Longtitude { get; private set; }
        public decimal Latitude { get; private set; }
        public string Address { get; private set; }

        public UserDevice(long userId, long productId, decimal longtitude,
            decimal latitude, string address)
        {
            UserId = userId;
            ProductId = productId;

            //MAP
            Longtitude = longtitude;
            Latitude = latitude;
            Address = address;
        }

        public void Edit(long productId, decimal longtitude,
            decimal latitude, string address)
        {
            ProductId = productId;

            //MAP
            Longtitude = longtitude;
            Latitude = latitude;
            Address = address;
        }
    }
}
