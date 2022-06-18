using _0_Framework.Domain;
using ShopManagement.Domain.SellerProductAgg;

namespace ShopManagement.Domain.SellerProductMediaAgg
{
    public class SellerProductMedia:BaseEntity
    {
        public string MediaURL { get; private set; }
        public string MediaAlt { get; private set; }
        public string MediaTitle { get; private set; }
        public bool IsSelectedBySeller { get; private set; }
        public bool IsMediaImage { get; set; }

        //
        public long UserId { get; private set; }

        //Relations
        public long SellerProductId { get; private set; }
        //public SellerProduct SellerProduct{ get;private set; }

        //Using TO Create seller gallery Picture
        public SellerProductMedia(string mediaURL, long userId)
        {
            MediaURL = mediaURL;
            UserId = userId;
            SellerProductId = 0;

            IsSelectedBySeller=false;
            IsMediaImage = true;
        }

        public void Choose(long sellerProductId)
        {
            SellerProductId=sellerProductId;
            IsSelectedBySeller = true;
        }
        public void MarkAsImage()
        {
            IsMediaImage = true;

        }
        public void MarkAsVideo()
        {
            IsMediaImage = false;

        }

        //تصاویر اپلود میشوند و در صورت تایید فروشنده، به گالری تصویر محصول مورد نظرش توی فروشگاه اضافه خواهند شد
    }
}
