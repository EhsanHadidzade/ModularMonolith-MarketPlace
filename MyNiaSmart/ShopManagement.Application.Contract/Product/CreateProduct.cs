using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Product
{
    public class CreateProduct
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public double UnitPrice { get;  set; }
        public int ProductWeight { get;  set; }
        public string Dimensions { get;  set; }
        public string CountryMadeIn { get;  set; }
    }
}
