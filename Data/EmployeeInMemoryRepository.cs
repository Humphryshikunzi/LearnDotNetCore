using LearnDotNetCore.Interfaces;
using LearnDotNetCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace LearnDotNetCore.Data
{
    public class EmployeeInMemoryRepository : IEmployeeRepository
    {
        private  List<Employee> _employees;
        public EmployeeInMemoryRepository()
        {
            _employees = GetEmployeeData();
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
            var employee = _employees.FirstOrDefault(e => e.Id ==   employeeChange.Id);
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
        public List<Employee> GetEmployeeData()
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    FirstName = "Humphry",
                    Email = "humphry97@outlook.com",
                    Department = Department.Administration
                },
                new Employee()
                {
                    Id = 2,
                    FirstName ="Isaac",
                    Email = "Isaac@outlook.com",
                    Department = Department.IT

                },
                new Employee()
                {
                    Id = 3,
                    FirstName = "Lilian",
                    Email = "Lilian@outlook.com",
                    Department = Department.HR
                }
            };
            return employees;
        }

    }
}
