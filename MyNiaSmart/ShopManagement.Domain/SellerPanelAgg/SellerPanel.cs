using _0_Framework.Domain;
using ShopManagement.Domain.SellerProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.SellerPanelAgg
{
    public class SellerPanel : BaseEntity
    {
        public string Address { get; private set; }
        public string SellerMobileNumber { get; private set; }
        public string Capital { get; private set; }
        public string City { get; private set; }

        #region Default Fields that will display for creating each product
        public int DeliveryDurationForCity { get; private set; }
        public int DeliveryDurationForCapital { get; private set; }
        public int DeliveryDurationForOther { get; private set; }
        public int WarrantyTypeId { get; private set; }
        public int WarrantyAmount { get; private set; }

        //1=sellToNormalPeople 2=SellToServiceMan 3=BothCanSee
        public int BuyersCategory { get; private set; }
        public bool CanMarketerSee { get; private set; }
        #endregion

        public bool IsConfirmedByAdmin { get; private set; }
        public bool IsUserLegal { get; private set; }

        //IllegulUser
        public string StoreName { get; private set; }

        //legalUser
        public string CompanyName { get; private set; }
        public string CompanyRegistrationCode { get; private set; }
        public string CompanyEconomicCode { get; private set; }

        //relations
        public long UserId { get; private set; }
        public List<SellerProduct> SellerProducts{ get; private set; }

        public SellerPanel(string address, string sellerMobileNumber, int buyersCategory, bool canMarketerSee,
            bool isUserLegal, string storeName, string companyName, string companyRegistrationCode, string companyEconomicCode,
            long userId, string capital, string city,int deliveryDurationForCity,int deliveryDurationForCapital,int deliveryDurationForOther,
            int warrantyTypeId,int warrantyAmount)
        {
            Address = address;
            SellerMobileNumber = sellerMobileNumber;
            BuyersCategory = buyersCategory;
            CanMarketerSee = canMarketerSee;
            IsUserLegal = isUserLegal;
            StoreName = storeName;
            CompanyName = companyName;
            CompanyRegistrationCode = companyRegistrationCode;
            CompanyEconomicCode = companyEconomicCode;
            UserId = userId;
            Capital = capital;
            City = city;
            DeliveryDurationForCity = deliveryDurationForCity;
            DeliveryDurationForCapital = deliveryDurationForCapital;
            DeliveryDurationForOther = deliveryDurationForOther;
            WarrantyTypeId = warrantyTypeId;
            WarrantyAmount= warrantyAmount;
            IsConfirmedByAdmin = false;

            SellerProducts = new List<SellerProduct>();
        }

        public void Confirm()
        {
            IsConfirmedByAdmin = true;
        }
        public void Cancel()
        {
            IsConfirmedByAdmin = false;
        }

    }
}
