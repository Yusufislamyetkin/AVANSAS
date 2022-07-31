using Avansas.BusinessLayer.Abstract;
using Avansas.EntityLayer.Models;
using Avansas.UI.Methods;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Avansas.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly IUserService _userService;
        private readonly ILoginService _loginService;

        public LoginController(IUserService userService, ILoginService loginService)
        {
            _userService = userService;
            _loginService = loginService;

        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User _user)
        {

            if (ModelState.ErrorCount > 4)
            {
                return View(_user);
            }

            User user = await _userService.GetByUser(_user);

            if (user == null)
            {
                TempData["WrongAcccess"] = "Kullanıcı mail ya da parola hatalı.";
                return View();
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, await _loginService.Login(user));


            return RedirectToAction("Route", "Login");


        }

        [HttpGet]
        public IActionResult Route()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.Claims.Select(x => x.Value).FirstOrDefault();

            if (claims == EnumRole.Admin) { return RedirectToAction("UserList", "Admin"); }
            else if (claims == EnumRole.User) { return RedirectToAction("UserList", "User"); }

            return RedirectToAction("Route", "Login");

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }

    }
}
