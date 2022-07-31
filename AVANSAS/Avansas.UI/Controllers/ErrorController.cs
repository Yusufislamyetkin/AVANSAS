using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Avansas.UI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statuscode}")]
        [AllowAnonymous]
        public IActionResult HttpsStatusCodeHandler(int statuscode)
        {
            switch (statuscode)
            {
                case 404:
                    { ViewBag.errorMessage = "Hata : 404 ! ";
                        ViewBag.errorMessage2 = "İstediğiniz sayfa bulunamadı";
                    }
         
                    break;
            }
            return View();
        }
    }
}
