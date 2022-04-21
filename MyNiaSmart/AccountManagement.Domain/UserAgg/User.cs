using _0_Framework.Domain;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.UserPersonalityAgg;
using AccountManagement.Domain.UserRoleAgg;
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

        public int Grade { get;private set; }
        #endregion

        #region Relations
        public List<UserRole> UserRoles { get; private set; }
        public List<UserPersonality> UserPersonalities{ get; set; }
        #endregion

        public User(string fullName, string mobileNumber, string capital
            , string city, string address, string nationalCode
            , DateTime? birthday, string profilePhoto, string introductorFullname
            , string introductorMobileNumber)
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

            UserRoles = new List<UserRole>();
            UserPersonalities = new List<UserPersonality>();
        }

        public void Edit(string fullName, string mobileNumber, string capital
            , string city, string address, string nationalCode
            , DateTime? birthday, string profilePhoto, string introductorFullname
            , string introductorMobileNumber)
        {
            FullName = fullName;
            MobileNumber = mobileNumber;
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

        //Here we should make a new method to Change Grade of user
    }
}
