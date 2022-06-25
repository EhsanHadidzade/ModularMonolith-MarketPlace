using _0_Framework.Domain;
using AccountManagement.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UserAddressAgg
{
    public class UserAddress : BaseEntity
    {
        public string Capital { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string PlaqueNumber { get; private set; }
        public string PostalCode { get; private set; }
        public string MobileNumber { get; private set; }

        //realtion
        public long UserId { get; private set; }
        public User User { get; private set; }

        public UserAddress(string capital, string city, string address, string plaqueNumber,
            string postalCode, string mobileNumber, long userId)
        {
            Capital = capital;
            City = city;
            Address = address;
            PlaqueNumber = plaqueNumber;
            PostalCode = postalCode;
            MobileNumber = mobileNumber;
            UserId = userId;
        }

        public void Edit(string capital, string city, string address, string plaqueNumber,
            string postalCode, string mobileNumber)
        {
            Capital = capital;
            City = city;
            Address = address;
            PlaqueNumber = plaqueNumber;
            PostalCode = postalCode;
            MobileNumber = mobileNumber;
        }
    }
}
