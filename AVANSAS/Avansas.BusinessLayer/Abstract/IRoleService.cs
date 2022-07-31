using Avansas.EntityLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avansas.BusinessLayer.Abstract
{
    public interface IRoleService : IService<Role>
    {
        Task<List<Role>> GetByUserRole(UserRole userRole);
        List<SelectListItem> RoleList();
    }
}
