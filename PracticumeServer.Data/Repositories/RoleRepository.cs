using Microsoft.EntityFrameworkCore;
using PracticumeServer.Core.Entites;
using PracticumeServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Data.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetRoleAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<Role> GetRoleByIdAsync(int id)
        {

            return await _context.Roles.FindAsync(id);
        }
        public async Task<Role> AddAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return await _context.Roles.FindAsync(role.Id);
        }
        public async Task<Role> DeleteAsync(int id)
        {
            Role role;
            role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
            return role;
        }
        public async Task<Role> PutAsync(int id, Role role)
        {
            Role existRole;
            existRole = await _context.Roles.FirstOrDefaultAsync(e => e.Id == id);
            if (existRole != null)
            {
                existRole.Description = role.Description;

                await _context.SaveChangesAsync();
            }

            return existRole;
        }
        public async Task<bool> IsRoleIdExist(int roleID)
        {
            Role existRole;
            existRole = await _context.Roles.FirstOrDefaultAsync(e => e.Id == roleID);

            return existRole != null;
        }
    }
}
