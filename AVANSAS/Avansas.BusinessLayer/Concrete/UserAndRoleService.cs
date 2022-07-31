using Avansas.BusinessLayer.Abstract;
using Avansas.EntityLayer.Dto;
using Avansas.EntityLayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Avansas.BusinessLayer.Concrete
{
    public class UserAndRoleService: IUserAndRoleService
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;


        public UserAndRoleService(IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _roleService = roleService;


        }

        UserRole userRole = new UserRole();

        public async Task<bool> AddUserAndRole(UserAndRole userandrole)
        {
            await _userService.AddAsync(userandrole.UserValue);
            userRole.UserId = userandrole.UserValue.UserId;
            userRole.RoleId = userandrole.RoleValue.RoleId;
            await _userRoleService.AddAsync(userRole);

            return true;
        }

        public async Task<bool> AddUserAndRole(User user)
        {
        
            await _userService.AddAsync(user);
            userRole.UserId = user.UserId;

           var roleValue = _roleService.Where(x => x.Name == "User").FirstOrDefault();
            userRole.RoleId = roleValue.RoleId;

            await _userRoleService.AddAsync(userRole);

            return true;
        }
    }
}
