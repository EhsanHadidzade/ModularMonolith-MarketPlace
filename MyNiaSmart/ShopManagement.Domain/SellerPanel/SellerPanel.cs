using _0_Framework.Domain;
using AccountManagement.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SellerPanel
{
    public class SellerPanel:BaseEntity
    {
        public string StoreName { get; private set; }
        public string Address { get; private set; }
        public string StoreMobileNumber { get; private set; }

        //1=sellToNormalPeople 2=SellToServiceMan 3=BothCanSee
        public int BuyersCategory { get; private set; }
        public bool CanMarketerSee { get;private set; }
        public bool IsConfirmedByAdmin { get; private set; }

        //relations
        public long UserId { get;private set; }

        public SellerPanel(string storeName, string address, string storeMobileNumber,
            int buyersCategory, bool canMarketerSee, long userId)
        {
            StoreName = storeName;
            Address = address;
            StoreMobileNumber = storeMobileNumber;
            BuyersCategory = buyersCategory;
            CanMarketerSee = canMarketerSee;
            UserId = userId;
        }
        public void Confirm()
        {
            IsConfirmedByAdmin = true;
        }
        public void Cancel()
        {
            IsConfirmedByAdmin = false;
        }

    }
}
