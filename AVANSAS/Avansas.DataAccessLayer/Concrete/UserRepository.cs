using Avansas.DataAccessLayer.Abstract;
using Avansas.DataAccessLayer.Context;
using Avansas.EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Avansas.DataAccessLayer.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<User> GetByUser(User user)
        {
            return await _context.Users.Where(x => x.Mail == user.Mail && x.Password == user.Password).FirstOrDefaultAsync();
        }

        public async Task<bool> GetByMail(string mail)
        {
            return await _context.Users.AnyAsync(x => x.Mail == mail);
        }


    }
}
