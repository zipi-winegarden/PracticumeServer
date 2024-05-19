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
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            var res = await _context.Employees.
                Include(e => e.EmployeeRoles).ThenInclude(emp => emp.Role).ToListAsync();
            return res;
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var res = await _context.Employees.Include(e => e.EmployeeRoles).ThenInclude(emp => emp.Role).FirstOrDefaultAsync(e => e.Id == id);
            return res;
        }
     
        public async Task<Employee> AddAsync(Employee employee)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == employee.Id);
            if (emp == null)
            {
                employee.EmployeeRoles = employee.EmployeeRoles.GroupBy(r => r.RoleId).Select(g => g.First()).ToList();
                employee.IsActive = true;
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();

            }
            return await _context.Employees.Include(e => e.EmployeeRoles).ThenInclude(emp => emp.Role).FirstOrDefaultAsync(e => e.Id == employee.Id);
        }
        public async Task<Employee> DeleteAsync(int id)
        {
            Employee employee;
            employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.IsActive = false;
                await _context.SaveChangesAsync();
            }
            return employee;
        }
        public async Task<Employee> PutAsync(int id, Employee employee)
        {
            Employee existEmployee;
            existEmployee = await _context.Employees.Include(e => e.EmployeeRoles).FirstOrDefaultAsync(e => e.Id == id);
            if (existEmployee != null)
            {
                existEmployee.Gender = employee.Gender;
                existEmployee.BirthDate = employee.BirthDate;
                existEmployee.EntryWorkDate = employee.EntryWorkDate;
                existEmployee.FirstName = employee.FirstName;
                existEmployee.LastName = employee.LastName;
                existEmployee.IDNumber = employee.IDNumber;
                existEmployee.IsActive = employee.IsActive;

                existEmployee.EmployeeRoles = employee.EmployeeRoles.GroupBy(r => r.RoleId).Select(emp => emp.First()).ToList();
                await _context.SaveChangesAsync();
            }

            return existEmployee;
        }
        public async Task<bool> IsEmployeeExitByIdNumber(string idNumber)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(e => e.IDNumber == idNumber);
            return emp != null;
        }
    }

}
