using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerProductMedia
{

    // To use in seller panel of client Side
    public class SellerGalleryViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string MediaURL { get; set; }
        public bool IsMediaImage { get; set; }
        public long SellerProductId { get; set; }
        public bool IsSelectedBySeller { get; set; }
    }
}
