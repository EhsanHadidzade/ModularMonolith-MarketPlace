namespace ShopManagement.Application.Contract.SellerProductMedia
{


    //To Show The List of users In Admin panel in file manager TO Display their Media Gallerries
    public class UserWithMediaViewModel
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public int PictureCount { get; set; }
        public int VideoCount { get; set; }
        public long UserMediaDiskSpace { get; set; }
        public int PicturePerProduct { get; set; }

    }
}

