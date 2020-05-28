using LearnDotNetCore.Interfaces;
using LearnDotNetCore.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LearnDotNetCore.Data
{
    public class EmployeeSqlRepository : IEmployeeRepository
    {
        private List<Employee> _employees;
        public EmployeeSqlRepository()
        {
      //      _employees = GetEmployeeData().Result;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }
        public Employee GetEmployeeById(int id)
        {
            return _employees.Where(e => e.Id == id).FirstOrDefault();
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }
        public Employee UpDateEmployee(Employee employeeChange)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == employeeChange.Id);
            if (employee != null)
            {
                employee.FirstName = employeeChange.FirstName;
                employee.Department = employee.Department;
                employee.LastName = employee.LastName;
                employee.Email = employee.Email;
            }
            return employee;
        }
        public Employee DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return employee;
        }
        private async Task<List<Employee>> GetEmployeeData()
        {
           var baseUri = "https://localhost:44336/";
            var httpClient = new HttpClient();
            var jsonResponse = await httpClient.GetAsync(baseUri+ "api/Employee/all").ConfigureAwait(false);
            var data = await jsonResponse.Content.ReadAsStringAsync();
            var  employees = JsonConvert.DeserializeObject<List<Employee>>(data);
            return employees;
        }

    }
}
