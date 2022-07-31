using Avansas.EntityLayer.Models;
using Microsoft.AspNetCore.DataProtection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avansas.BusinessLayer.Abstract
{
    public interface IUserService : IService<User>
    {
        Task<User> GetByUser(User user);
        Task<bool> GetByMail(string mail);
         Task<User> GetByMailUser(string mail);
        Task<User> GetByUserID(int id);
        Task<bool> GetByMyMail(int id, string mail);
        Task<List<User>> UserEncrypedId(IDataProtector dataProtector);
    }
}
