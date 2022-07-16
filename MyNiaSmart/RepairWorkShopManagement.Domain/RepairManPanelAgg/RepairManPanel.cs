using _0_Framework.Domain;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.RepairManPanelAgg
{
    public class RepairManPanel:BaseEntity
    {
        public string CommericalFullName { get; private set; } //نام تجاری
        public string Capital { get; private set; } 
        public string City { get; private set; }
        public string Address { get; private set; }
        public string MobileNumber { get; private set; }
        public string ShortResume { get; private set; } //رزمه مختصر 
        public bool IsConfirmedByAdmin { get; private set; }


        #region Default Fields that will display for creating each RepairMan Services
        public bool CanMarketerSee { get; private set; } //امکان بازار یابی به شما داده شود؟ 
        public int WarrantyTypeId { get; private set; }
        public int WarrantyAmount { get; private set; }
        #endregion

        //relation
        public long UserId { get;private set; }
        public List<RepairManService> RepairManServices{ get;private set; }

        public RepairManPanel(string commericalFullName, string capital, string city, 
            string address, string mobileNumber, string shortResume, bool canMarketerSee,
            int warrantyTypeId, int warrantyAmount, long userId)
        {
            CommericalFullName = commericalFullName;
            Capital = capital;
            City = city;
            Address = address;
            MobileNumber = mobileNumber;
            ShortResume = shortResume;

            //Default
            CanMarketerSee = canMarketerSee;
            WarrantyTypeId = warrantyTypeId;
            WarrantyAmount = warrantyAmount;

            IsConfirmedByAdmin = false;

            //FK
            UserId = userId;
            RepairManServices= new List<RepairManService>();
        }

        public void ConfirmByAdmin()
        {
            IsConfirmedByAdmin=true;
        }
      
    }
}
