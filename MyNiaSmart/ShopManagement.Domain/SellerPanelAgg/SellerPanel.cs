using _0_Framework.Domain;
using ShopManagement.Domain.SellerProductAgg;
using ShopManagement.Domain.TransitionAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.SellerPanelAgg
{
    public class SellerPanel : BaseEntity
    {
        public string Address { get; private set; }
        public string SellerMobileNumber { get; private set; }
        public string Capital { get; private set; }
        public string City { get; private set; }

        #region Default Fields that will display for creating each productsellerpan
        public int DeliveryDurationForCity { get; private set; }
        public int DeliveryDurationForCapital { get; private set; }
        public int DeliveryDurationForOther { get; private set; }
        public int WarrantyTypeId { get; private set; }
        public int WarrantyAmount { get; private set; }

        //1=sellToNormalPeople 2=SellToRepairMan 3=BothCanSee
        public int BuyersCategory { get; private set; }
        public bool CanMarketerSee { get; private set; }
        #endregion

        public bool IsConfirmedByAdmin { get; private set; }
        public bool IsUserLegal { get; private set; }
        public bool IsSpecial { get;private set; }

        //IllegulUser
        public string StoreName { get; private set; }

        //legalUser
        public string CompanyName { get; private set; }  //نام شرکت
        public string CompanyRegistrationCode { get; private set; } //کد ثبت
        public string CompanyEconomicCode { get; private set; } //شناسه اقتصادی

        //relations
        public long UserId { get; private set; }
        public List<SellerProduct> SellerProducts{ get; private set; }
        public List<Transition> Transitions{ get; private set; }

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
            IsSpecial=false;

            SellerProducts = new List<SellerProduct>();
            Transitions = new List<Transition>();
        }

        public void ConfirmByAdmin()
        {
            IsConfirmedByAdmin = true;
        }
        public void CancelByAdmin()
        {
            IsConfirmedByAdmin = false;
        }
        public void SelectAsSpecial()
        {
            IsSpecial = true;
        }
    }
}
