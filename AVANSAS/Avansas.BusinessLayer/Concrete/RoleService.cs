using Avansas.BusinessLayer.Abstract;
using Avansas.DataAccessLayer.Abstract;
using Avansas.EntityLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansas.BusinessLayer.Concrete
{
    public class RoleService : Service<Role>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRepository<Role> _repository;
        public RoleService(IRepository<Role> repository, IUnitOfWork unitOfWork, IRoleRepository roleRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _roleRepository = roleRepository;
        }

        public async Task<List<Role>> GetByUserRole(UserRole userRole)
        {
            return await _roleRepository.GetByUserRoleAsync(userRole);
        }

        public List<SelectListItem> RoleList()
        {
            List<SelectListItem> RoleList = (from i in  _repository.GetAll().ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.RoleId.ToString()

                                             }

                                          ).ToList();

            return RoleList;
        }
    }
}
