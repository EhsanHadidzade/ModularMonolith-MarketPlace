using _0_Framework.Domain;
using AccountManagement.Domain.CooperationRequestAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.UPAccountRequestsAgg;
using AccountManagement.Domain.UserPersonalityAgg;
//using AccountManagement.Domain.UserPersonalityRequestAgg;
using AccountManagement.Domain.UserRoleAgg;
using AccountManagement.Domain.WalletAgg.BusinessWalletAgg;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using System;
using System.Collections.Generic;

namespace AccountManagement.Domain.UserAgg
{
    public class User : BaseEntity
    {
        #region Properties
        //Compulsory
        public string FullName { get; private set; }
        public string MobileNumber { get; private set; }

        //optional 
        public string Capital { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string NationalCode { get; private set; }
        public DateTime? Birthday { get; private set; }
        public string ProfilePhoto { get; private set; }
        public string IntroductorFullname { get; private set; }
        public string IntroductorMobileNumber { get; private set; }

        //To Find Who is the admin of a group. 
        public bool IsAdmin { get; private set; }

        //Service girande
        public bool IsClient { get; private set; }  

        //User experience
        public long Experience { get; private set; }
        public int Grade { get;private set; }

        //Activation
        public bool IsActive { get; private set; }
        public string ActiveCode { get; private set; }
        #endregion

        #region Relations
        public List<UserRole> UserRoles { get; private set; }
        public List<UserCooperationRequest> UserCooperationRequests { get; private set; }
        public List<UserPersonality> UserPersonalities{ get; set; }
        //public List<UserPersonalityRequest> UserPersonalityRequests { get; private set; }
        public UpAccountRequest UpAccountRequest{ get; private set; }
        public PersonalWallet PersonalWallet{ get; private set; }
        public BusinessWallet BusinessWallet{ get; private set; }
        #endregion

        public User(string fullName, string mobileNumber)
        {
            FullName = fullName;
            MobileNumber = mobileNumber;
            IsActive = false;
            Grade = 1;
            Experience = 1;
        }

        public User(string fullName, string mobileNumber, string capital
            , string city, string address, string nationalCode
            , DateTime? birthday, string profilePhoto, string introductorFullname
            , string introductorMobileNumber, long experience)
        {
            FullName = fullName;
            MobileNumber = mobileNumber;
            Capital = capital;
            City = city;
            Address = address;
            NationalCode = nationalCode;
            Birthday = birthday;
            Grade = 1;
            IsClient = true;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;

            IntroductorFullname = introductorFullname;
            IntroductorMobileNumber = introductorMobileNumber;

            Experience = experience;

            UserRoles = new List<UserRole>();
            UserPersonalities = new List<UserPersonality>();
        }

        public void Edit(string fullName, string capital
            , string city, string address, string nationalCode
            , DateTime? birthday, string profilePhoto, string introductorFullname
            , string introductorMobileNumber)
        {
            FullName = fullName;
            Capital = capital;
            City = city;
            Address = address;
            NationalCode = nationalCode;
            Birthday = birthday;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;

            IntroductorFullname = introductorFullname;
            IntroductorMobileNumber = introductorMobileNumber;
          
        }

        public void GenerateActiveCode(string activeCode)
        {
            ActiveCode= activeCode;
        }
        public void ActiveUser()
        {
            IsActive=true;
        }
        public void DeActiveUser()
        {
            IsActive = false;
        }
        //Here we should make a new method to Change Grade of user
    }
}
