using LearnDotNetCore.Interfaces;
using LearnDotNetCore.Models;
using LearnDotNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LearnDotNetCore.Controllers
{
    public class EmployeeController : Controller
    {
        private  readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public ViewResult Employees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }


        [HttpGet]
        public ViewResult Employee(int? id)
        {
            var employee = _employeeRepository.GetEmployeeById(id.Value);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);

            }
            var getEmployee = new EmployeeDTO()
            {
                PageTitle = "Employee Details",
                Employee = employee

            };

            return View(getEmployee);
        }



        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = _employeeRepository.AddEmployee(employee);
                return RedirectToAction("Employee", new { id = newEmployee.Id });
            }
            return View();
        }



        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(EditEmployee model)
        {

            if (ModelState.IsValid)
            {
                var employee = _employeeRepository.GetEmployeeById(model.Id);
                employee.FirstName = model.FirstName;
                employee.Email = model.Email;
                employee.Department = model.Department;
                // This code would be useful when I add photos
                //if (model.Photo != null)
                //{
                //    if (model.ExistingPhotoPath != null)
                //    {
                //        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "Images", model.ExistingPhotoPath);
                //        System.IO.File.Delete(filePath);
                //    }
                //    employee.PhotoPath = ProcessUploadedFile(model);
                //}

                return RedirectToAction("Employees");
            }
            return View();
        }
    }
}
