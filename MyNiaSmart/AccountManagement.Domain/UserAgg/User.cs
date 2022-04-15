using _0_Framework.Domain;
using System;

namespace AccountManagement.Domain.UserAgg
{
    public class User : BaseEntity
    {
        #region Properties
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string MobileNumber { get; private set; }

        //optional 
        public string Capital { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string NationalCode { get; private set; }
        public DateTime Birthday { get; private set; }
        public string ProfilePhoto { get; private set; }
        public string IntroductorFullname { get; private set; }
        public string IntroductorMobileNumber { get; private set; }
        #endregion

        #region Relations

        #endregion


        public User(string firstname, string lastname, string mobileNumber
            , string capital, string city, string address, string nationalCode
            , DateTime birthday, string profilePhoto, string introductorFullname
            , string introductorMobileNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
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

        public void Edit(string firstname, string lastname, string mobileNumber
            , string capital, string city, string address, string nationalCode
            , DateTime birthday, string profilePhoto, string introductorFullname
            , string introductorMobileNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
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
    }
}
