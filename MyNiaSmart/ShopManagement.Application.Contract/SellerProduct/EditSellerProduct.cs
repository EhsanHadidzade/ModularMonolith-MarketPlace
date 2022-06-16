using ShopManagement.Application.Contract.SellerProductMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerProduct
{
    public class EditSellerProduct:CreateSellerProduct
    {
        public long Id { get; set; }
        public List<SellerGalleryViewModel> SelectedMedias { get; set; }
    }
}
