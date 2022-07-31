using Avansas.EntityLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avansas.DataAccessLayer.Abstract
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetByUserRoleAsync(UserRole userRole);
    }
}
