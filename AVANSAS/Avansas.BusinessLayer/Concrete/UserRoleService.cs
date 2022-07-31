using Avansas.BusinessLayer.Abstract;
using Avansas.DataAccessLayer.Abstract;
using Avansas.EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Avansas.BusinessLayer.Concrete
{
    public class UserRoleService : Service<UserRole>, IUserRoleService
    {
        private readonly IRepository<UserRole> _repository;
        public UserRoleService(IRepository<UserRole> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public async Task<UserRole> GetUserRoleByUserIdAsync(int userId)
        {
            return await _repository.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }

     
    }
}
