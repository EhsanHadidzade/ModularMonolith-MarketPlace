using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerProductMedia
{
    public class CreateMediaForSellerGallery
    {
        public IFormFile Media { get; set; }
    }
}
