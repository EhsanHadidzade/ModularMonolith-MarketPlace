using ShopManagement.Application.Contract.SellerProductMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerProduct
{
    //To Show Details of a product that is selling by an specific seller
    public class SellerProductDetailsToShowViewModel
    {
        public long Id { get; set; }
        public string FarsiTitle { get; set; }
        public string EngTitle { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }

        public string PartNumber { get; set; }
        public int ProductWeight { get; set; }
        public string Dimensions { get; set; }
        public string CountryMadeIn { get; set; }

        public string ProductBrandTitle { get; set; }
        public string ProductModelTitle { get; set; }
        public string ProductStatusTitle { get; set; }
        public string ProductTypeTitle { get; set; }
        public string ProductUsageTypeTitle { get; set; }


        public int MarketerSharePercent { get; set; }
        public long MarketerShareAmount { get; set; }
        public int DeliveryDurationForCity { get; set; }
        public int DeliveryDurationForCapital { get; set; }
        public int DeliveryDurationForOther { get; set; }
        public bool CanMarketerSee { get; set; }
        public int BuyersCategory { get; set; }
        public int WarrantyTypeId { get; set; }
        public int WarrantyAmount { get; set; }


        public bool IsUserLegal  { get; set; }
        public string SellerName { get; set; }
        public string SellerPanelCapital { get; set; }
        public string SellerPanelCity { get; set; }
        public string SellerPanelPhoneNumber { get; set; }

        public List<SellerGalleryViewModel> SelectedMedias { get; set; }

    }
}
