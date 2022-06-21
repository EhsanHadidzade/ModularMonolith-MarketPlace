using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.SellerProductMedia;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SellerProductMediaController : Controller
    {
        private readonly ISellerProductMediaApplication _sellerProductMediaApplication;

        public SellerProductMediaController(ISellerProductMediaApplication sellerProductMediaApplication)
        {
            _sellerProductMediaApplication = sellerProductMediaApplication;
        }

        public IActionResult Index()
        {
            var usersWithMedias=_sellerProductMediaApplication.GetUsersWithMedias();
            return View(usersWithMedias);
        }

        public IActionResult ShowUserMedia(long id)
        {
            //id==UserId passed to find their Medias from seller product media table
            var userMedias = _sellerProductMediaApplication.GetUserGalleryMediasByUserId(id);
            return PartialView(userMedias);
        }
    }
}
