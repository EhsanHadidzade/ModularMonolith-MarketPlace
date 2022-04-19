namespace AccountManagement.Application.Contract.User
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string ProfilePhoto { get; set; }
        public string Role { get; set; }
        public int Grade { get; set; }
        public string CreationDate { get; set; }
    }
}
