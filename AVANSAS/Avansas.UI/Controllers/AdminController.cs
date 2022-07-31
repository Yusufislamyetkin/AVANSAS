using Avansas.BusinessLayer.Abstract;
using Avansas.EntityLayer.Dto;
using Avansas.EntityLayer.Models;
using Avansas.UI.Filters;
using Avansas.UI.Methods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Avansas.UI.Controllers
{
    [Authorize(Roles = EnumRole.Admin)]
    [CustomHandleExceptionFilterAttribute(ErrorPage = "ErrorPage")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;
        private readonly IUserAndRoleService _userAndRoleService;
        private readonly IDataProtector _dataProtector;

        public AdminController(IUserService userService, IUserRoleService userRoleService, IRoleService roleService, IUserAndRoleService userAndRoleService, IDataProtectionProvider dataProtectionProvider)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _roleService = roleService;
            _userAndRoleService = userAndRoleService;
            _dataProtector = dataProtectionProvider.CreateProtector("AdminController");

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
            ViewBag.RoleV = _roleService.RoleList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UserAndRole userandrole)
        {
            if (!ModelState.IsValid)
            {
                return View(userandrole);
            }

            if (await _userService.GetByMail(userandrole.UserValue.Mail))
            {
                TempData["AddWrong"] = "* Mail başka bir kullanıcı tarafından kullanılıyor lütfen başka bir mail girin.";
                return RedirectToAction("AddUser", "Admin");

            }

            if (await _userAndRoleService.AddUserAndRole(userandrole))
            {
                TempData["AddStatus"] = "true";
                return RedirectToAction("UserList", "Admin");
            }

            return RedirectToAction("UserList", "Admin");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            int decryptedId = int.Parse(_dataProtector.Unprotect(id));

            var DataRole = await _userRoleService.GetUserRoleByUserIdAsync(decryptedId);
            var DataUser = await _userService.GetByUserID(decryptedId);


            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.Name;

            if (decryptedId == _userService.GetByMailUser(claims).Result.UserId)
                return Json(new { success = false });


            await _userRoleService.RemoveAsync(DataRole);
            await _userService.RemoveAsync(DataUser);

            return Json(new { success = true });
        }


        [HttpGet]
        public async Task<IActionResult> UpdateUser(string id)
        {
            int decryptedId = int.Parse(_dataProtector.Unprotect(id));
            var user = await _userService.GetByUserID(decryptedId);
            user.EncrypedId = id;

            ViewBag.RoleV = _roleService.RoleList();
            ViewBag.User = user;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(UserAndRole data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.Name;



            if (await _userService.GetByMail(data.UserValue.Mail) && await _userService.GetByMyMail(data.UserValue.UserId, data.UserValue.Mail))
            {
                TempData["UpdateWrong"] = "* Mail başka bir kullanıcı tarafından kullanılıyor lütfen başka bir mail girin.";
                return RedirectToAction("UpdateUser", "Admin", new { id = data.UserValue.EncrypedId });
            }

            if (data.UserValue.UserId == _userService.GetByMailUser(claims).Result.UserId)
            {
                await _userService.UpdateAsync(data.UserValue, data.UserValue.UserId);
                await _userRoleService.UpdateAsync(new UserRole { RoleId = data.RoleValue.RoleId, UserId = data.UserValue.UserId });
                TempData["UpdateMyMail"] = "*";
                return RedirectToAction("Logout", "Login");
            }


            await _userService.UpdateAsync(data.UserValue, data.UserValue.UserId);
            await _userRoleService.UpdateAsync(new UserRole { RoleId = data.RoleValue.RoleId, UserId = data.UserValue.UserId });
            TempData["UpdateStatus"] = "true";
            return RedirectToAction("UserList", "Admin");



        }

    }
}
