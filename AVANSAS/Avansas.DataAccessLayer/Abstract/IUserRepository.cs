using Avansas.EntityLayer.Models;
using System.Threading.Tasks;

namespace Avansas.DataAccessLayer.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUser(User user);
        Task<bool> GetByMail(string mail);

    }
}
