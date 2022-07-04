using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.OrderItem
{
    public class OrderItemViewModel
    {
        public long Id { get; set; }
        public long SellerProductId { get; set; }
        public long TransitionId { get; set; }
        public string TransitionTrackingNumber { get; set; }
        public string SellerProductTitle { get; set; }
        public string SellerShopName { get; set; }
        public string SellerCapital { get; set; }
        public string SellerCity { get; set; }
        public int SellerDeliveryDurationForCity { get; set; }
        public int SellerDeliveryDurationForCapital { get; set; }
        public int SellerDeliveryDurationForOther { get; set; }
        public long OrderId { get; set; }
        public long UnitPrice { get; set; }
        public string PictureURL { get; set; }
        public int Count { get; set; }
    }
}
