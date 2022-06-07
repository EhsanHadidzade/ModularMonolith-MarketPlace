using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.SellerPanelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SellerProductAgg
{
    public class SellerProduct:BaseEntity
    {
        public long SellerPanelId { get; private set; }
        public long ProductId { get; private set; }
        public long Price { get; private set; }
        public string Description { get;private set; }
        public int MarketerSharePercent { get; set; }
        public long MarketerShareAmount { get; set; }

        #region Default Values that are filled in sellerPanelRequest
        public int DeliveryDurationForCity { get; private set; }
        public int DeliveryDurationForCapital { get; private set; }
        public int DeliveryDurationForOther { get; private set; }
        public bool CanMarketerSee { get; private set; }
        public int BuyersCategory { get; private set; }
        public int WarrantyTypeId { get; private set; }
        public int WarrantyAmount { get; private set; }
        #endregion

        public bool isConfirmedByAdmin { get; private set; }

        //relations
        public SellerPanel SellerPanel { get; private set; }
        public Product Product{ get; private set; }

        public SellerProduct(long sellerPanelId, long productId, long price,
            string description, int marketerSharePercent, long marketerShareAmount,
            int deliveryDurationForCity, int deliveryDurationForCapital, int deliveryDurationForOther,
            bool canMarketerSee, int buyersCategory, int warrantyTypeId, int warrantyAmount)
        {
            SellerPanelId = sellerPanelId;
            ProductId = productId;
            Price = price;
            Description = description;
            MarketerSharePercent = marketerSharePercent;
            MarketerShareAmount = marketerShareAmount;

            DeliveryDurationForCity = deliveryDurationForCity;
            DeliveryDurationForCapital = deliveryDurationForCapital;
            DeliveryDurationForOther = deliveryDurationForOther;
            CanMarketerSee = canMarketerSee;
            BuyersCategory = buyersCategory;
            WarrantyTypeId = warrantyTypeId;
            WarrantyAmount = warrantyAmount;

            isConfirmedByAdmin = false;
        }

        public void Edit(long productId, long price, string description,
            int marketerSharePercent, long marketerShareAmount, int deliveryDurationForCity,
            int deliveryDurationForCapital, int deliveryDurationForOther, bool canMarketerSee,
            int buyersCategory, int warrantyTypeId, int warrantyAmount)
        {
            ProductId = productId;
            Price = price;
            Description = description;
            MarketerSharePercent = marketerSharePercent;
            MarketerShareAmount = marketerShareAmount;

            DeliveryDurationForCity = deliveryDurationForCity;
            DeliveryDurationForCapital = deliveryDurationForCapital;
            DeliveryDurationForOther = deliveryDurationForOther;
            CanMarketerSee = canMarketerSee;
            BuyersCategory = buyersCategory;
            WarrantyTypeId = warrantyTypeId;
            WarrantyAmount = warrantyAmount;
        }

        public void ConfirmByAdmin()
        {
            isConfirmedByAdmin = true;
        }
    }
}
