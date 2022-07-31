using Avansas.EntityLayer.Dto;
using Avansas.EntityLayer.Models;
using System.Threading.Tasks;

namespace Avansas.BusinessLayer.Abstract
{
    public interface IUserAndRoleService
    {
        Task<bool> AddUserAndRole(UserAndRole userandrole);
        Task<bool> AddUserAndRole(User user);
    }
}
