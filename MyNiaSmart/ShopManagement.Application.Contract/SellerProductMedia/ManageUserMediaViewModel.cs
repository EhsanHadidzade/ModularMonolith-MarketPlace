using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerProductMedia
{
    // to manage Seller Medias in Admin Panel
    public class ManageUserMediaViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public bool IsMediaImage { get; set; }
        public string MediaURL { get; set; }
        //public string SellerName { get; set; }

    }
}

