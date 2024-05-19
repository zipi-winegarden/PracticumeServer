﻿using PracticumeServer.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Core.Repositories
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<Role>> GetRoleAsync();
        public Task<Role> GetRoleByIdAsync(int id);
        public Task<Role> AddAsync(Role role);
        public Task<Role> DeleteAsync(int id);
        public Task<Role> PutAsync(int id, Role role);
        public Task<bool> IsRoleIdExist(int roleID);
    }
}
