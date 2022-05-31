using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerProduct
{
    public class CreateSellerProduct
    {
        public long SellerPanelId { get;  set; }
        public long ProductId { get;  set; }
        public long Price { get;  set; }
        public string Description { get;  set; }
        public int MarketerSharePercent { get; set; }
        public long MarketerShareAmount { get; set; }

        #region Default Values that are filled in sellerPanelRequest
        public int DeliveryDurationForCity { get;  set; }
        public int DeliveryDurationForCapital { get;  set; }
        public int DeliveryDurationForOther { get;  set; }
        public bool CanMarketerSee { get;  set; }
        public int BuyersCategory { get;  set; }
        public int WarrantyTypeId { get;  set; }
        public int WarrantyAmount { get;  set; }
        #endregion
    }
}
