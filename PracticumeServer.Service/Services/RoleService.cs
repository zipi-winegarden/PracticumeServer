using PracticumeServer.Core.Entites;
using PracticumeServer.Core.Repositories;
using PracticumeServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<IEnumerable<Role>> GetRoleAsync()
        {
            return await _roleRepository.GetRoleAsync();
        }
        public async Task<Role> GetRoleByIdAsync(int id)
        {

            return await _roleRepository.GetRoleByIdAsync(id);
        }
        public async Task<Role> AddAsync(Role role)
        {

            return await _roleRepository.AddAsync(role);
        }
        public async Task<Role> DeleteAsync(int id)
        {

            return await _roleRepository.DeleteAsync(id);
        }
        public async Task<Role> PutAsync(int id, Role role)
        {

            return await _roleRepository.PutAsync(id, role);
        }
    }
}
