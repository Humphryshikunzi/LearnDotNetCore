using LearnDotNetCore.Models;
using System.Collections.Generic;

namespace LearnDotNetCore.Interfaces
{
    public interface  IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> GetAllEmployees();
        Employee AddEmployee(Employee employee);
        Employee UpDateEmployee(Employee employee);
        Employee DeleteEmployee(int id);
    }
}
