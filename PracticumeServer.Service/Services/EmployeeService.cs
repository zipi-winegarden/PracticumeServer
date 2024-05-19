using PracticumeServer.Core.Entites;
using PracticumeServer.Core.Repositories;
using PracticumeServer.Core.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Service.Services
{
    public class EmployeeService : IEmployeeServise
    {
        private readonly IEmployeeRepository _employeesRepository;
  
        public EmployeeService(IEmployeeRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            return await _employeesRepository.GetEmployeeAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {

            return await _employeesRepository.GetEmployeeByIdAsync(id);
        }
        public async Task<Employee> AddAsync(Employee employee)
        {
            IsValidEmployee(employee);
               if (await IsValidIdNumber(emp.IDNumber)==false)
            {
                throw new ArgumentException("IDNumber is already exist!");
            }
            return await _employeesRepository.AddAsync(employee);
        }
        public async Task<Employee> DeleteAsync(int id)
        {

            return await _employeesRepository.DeleteAsync(id);
        }
        public async Task<Employee> PutAsync(int id, Employee employee)
        {
            IsValidEmployee(employee);
            return await _employeesRepository.PutAsync(id, employee);
        }
        private async void IsValidEmployee(Employee emp)
        {

         
            if (!ContainsExactlyNineDigits(emp.IDNumber))
            {
                throw new ArgumentException("IDNumber is not valid!");
            }
            if (!ContainsOnlyLetters(emp.FirstName))
            {
                throw new ArgumentException("First Name is not valid!");
            }
            if (!ContainsOnlyLetters(emp.LastName))
            {
                throw new ArgumentException("Last Name is not valid!");
            }
            if (!IsValidBirthDate(emp.BirthDate))
            {
                throw new ArgumentException("Birth Date is not valid!");
            }
            if (!AllStartDaysAreValid(emp))
            {
                throw new ArgumentException("Not all start days are valid!");
            }
        }

        private async Task<bool> IsValidIdNumber(string empIdNumber)
        {
            if (await _employeesRepository.IsEmployeeExitByIdNumber(empIdNumber))
            {
                return false;
            }
            return true;
        }
        private bool ContainsExactlyNineDigits(string empIdNumber)
        {
            return empIdNumber.Length == 9 && empIdNumber.All(char.IsDigit);
        }
        private bool ContainsOnlyLetters(string empName)
        {
            return empName.All(char.IsLetter);
        }
        private bool IsValidBirthDate(DateTime empBirthDate)
        {
            return (empBirthDate < DateTime.Now);
        }
        private bool AllStartDaysAreValid(Employee emp)
        {
            return emp.EmployeeRoles.All(e => e.StartDate >= emp.EntryWorkDate);
        }


    }
}
