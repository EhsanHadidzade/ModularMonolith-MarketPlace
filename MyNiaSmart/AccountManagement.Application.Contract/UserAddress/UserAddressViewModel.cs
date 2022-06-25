namespace AccountManagement.Application.Contract.UserAddress
{
    public class UserAddressViewModel
    {
        public long Id { get; set; }
        public string MobileNumber { get; set; }
        public string PostalCode { get; set; }
        public string Capital { get; set; }
        public string City { get; set; }
        public long  UserId { get; set; }
        public string Address { get; set; }
    }
}
