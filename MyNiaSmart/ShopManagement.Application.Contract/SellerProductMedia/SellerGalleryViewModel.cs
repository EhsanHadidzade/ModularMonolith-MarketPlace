using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerProductMedia
{
    public class SellerGalleryViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string MediaURL { get; set; }
        public long SellerProductId { get; set; }
        public bool IsSelectedBySeller { get; set; }
    }
}
