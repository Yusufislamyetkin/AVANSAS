using Avansas.DataAccessLayer.Abstract;
using Avansas.DataAccessLayer.Context;
using Avansas.EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansas.DataAccessLayer.Concrete
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Role>> GetByUserRoleAsync(UserRole userRole)
        {
            return await _context.Roles.Where(x => x.RoleId == userRole.RoleId).ToListAsync();
        }
    }
}
