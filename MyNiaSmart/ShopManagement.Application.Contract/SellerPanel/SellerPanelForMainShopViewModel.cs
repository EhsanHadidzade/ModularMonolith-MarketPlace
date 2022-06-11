using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerPanel
{
    public class SellerPanelForMainShopViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public string SellerFullName { get; set; }
        public bool IsUserLegal { get; set; }
        public bool IsSellerSpecial { get; set; }
        public bool isConfirmedByAdmin { get; set; }
        public string StoreName { get; set; }
        public string CompanyName { get; set; }
        public int Grade { get;  set; }
        public long SpecificProductPrice { get; set; }
        public int WarrantyTypeId { get; set; }
        public int WarrantyAmount { get; set; }

    }
}
