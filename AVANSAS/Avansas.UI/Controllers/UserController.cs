using Avansas.BusinessLayer.Abstract;
using Avansas.EntityLayer.Models;
using Avansas.UI.Filters;
using Avansas.UI.Methods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Avansas.UI.Controllers
{

    [Authorize(Roles = EnumRole.User)]
    [CustomHandleExceptionFilterAttribute(ErrorPage = "ErrorPage")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserAndRoleService _userAndRoleService;
        private readonly IDataProtector _dataProtector;


        public UserController(IUserService userService,IUserAndRoleService userAndRoleService, IDataProtectionProvider dataProtectionProvider)
        {
            _userService = userService;
            _userAndRoleService = userAndRoleService;
         
            _dataProtector = dataProtectionProvider.CreateProtector("UserController");

        }

        public IActionResult UserList()
        {
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            var allobj = await _userService.UserEncrypedId(_dataProtector);

            return Json(new { data = allobj });
        }


        public IActionResult AddUser()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(User user)
        {

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (await _userService.GetByMail(user.Mail))
            {
                TempData["AddWrong"] = "* Mail başka bir kullanıcı tarafından kullanılıyor lütfen başka bir mail girin.";
                return RedirectToAction("AddUser", "User");

            }

           await _userAndRoleService.AddUserAndRole(user);

            TempData["AddStatus"] = "true";
            return RedirectToAction("UserList", "User");
        }


    }
}
