using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Product
{
    public class CreateProduct
    {
        public double UnitPrice { get; private set; }
        public int ProductWeight { get; private set; }
        public string Dimensions { get; private set; }
        public string CountryMadeIn { get; private set; }
    }
}
