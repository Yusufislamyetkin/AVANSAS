using Avansas.EntityLayer.Models;
using System.Threading.Tasks;

namespace Avansas.BusinessLayer.Abstract
{
    public interface IUserRoleService : IService<UserRole>
    {
        Task<UserRole> GetUserRoleByUserIdAsync(int userId);
    }
}
