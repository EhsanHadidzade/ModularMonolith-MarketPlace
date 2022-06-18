using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerProductMedia
{
    // to manage Seller Medias in Admin Panel
    public class SellerFilesManagerViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string PictureURL { get; set; }
        public bool IsMediaImage { get; set; }
        public string VideoURL { get; set; }
        public string SellerName { get; set; }
        public int PictureCount { get; set; }
        public int VideoCount { get; set; }
        public int PicturePerProduct { get; set; }


    }
}

