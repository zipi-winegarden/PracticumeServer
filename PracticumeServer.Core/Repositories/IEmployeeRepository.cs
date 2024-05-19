using PracticumeServer.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Core.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployeeAsync();
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<Employee> AddAsync(Employee employee);
        public Task<Employee> DeleteAsync(int id);
        public Task<Employee> PutAsync(int id, Employee employee);
        public Task<bool> IsEmployeeExitByIdNumber(string idNumber);

    }
}
