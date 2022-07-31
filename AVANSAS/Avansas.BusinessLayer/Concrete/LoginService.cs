
using Avansas.BusinessLayer.Abstract;
using Avansas.EntityLayer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Avansas.BusinessLayer.Concrete
{
    public class LoginService:ILoginService
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;


        public LoginService(IRoleService roleService, IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
            _roleService = roleService;


        }

        public async Task<ClaimsPrincipal> Login(User user)
        {
            ClaimsIdentity identity = null;

            var userRoles = await _userRoleService.GetUserRoleByUserIdAsync(user.UserId);
            var roles = await _roleService.GetByUserRole(userRoles);
            identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            foreach (var item in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, item.Name));
            }
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Mail));


            var principal = new ClaimsPrincipal(identity);

            return principal;

        }
    }
}
