using Avansas.BusinessLayer.Abstract;
using Avansas.DataAccessLayer.Abstract;
using Avansas.EntityLayer.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avansas.BusinessLayer.Concrete
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByUser(User user)
        {
            return await _userRepository.GetByUser(user);
        }

        public async Task<bool> GetByMail(string mail)
        {
            return await _userRepository.GetByMail(mail);

        }


        public async Task<bool> GetByMyMail(int id,string mail)
        {
           var value = await _userRepository.GetByIdAsync(id);
            if (value.Mail == mail)
            {
                return false;
            }

            return true;

        }

        public async Task<User> GetByMailUser(string mail)
        {
            return await _userRepository.Where(x => x.Mail == mail).FirstOrDefaultAsync();

        }

        public async Task<User> GetByUserID(int id)
        {
            return await _userRepository.Where(x => x.UserId == id).FirstOrDefaultAsync();
        }



        public async Task<List<User>> UserEncrypedId(IDataProtector dataProtector)
        {
            var value = await _userRepository.GetAll().ToListAsync();
   

            foreach (var item in value)
            {
                item.EncrypedId = dataProtector.Protect(item.UserId.ToString());
            }

            return value;

        }

    }
}
