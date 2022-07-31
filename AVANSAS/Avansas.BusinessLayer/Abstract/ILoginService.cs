using Avansas.EntityLayer.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Avansas.BusinessLayer.Abstract
{
    public interface ILoginService
    {
        Task<ClaimsPrincipal> Login(User user);
    }
}
