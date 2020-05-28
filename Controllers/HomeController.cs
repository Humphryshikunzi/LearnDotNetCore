using LearnDotNetCore.Interfaces;
using LearnDotNetCore.Models;
using LearnDotNetCore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IHostingEnvironment hostingEnvironment;

        
        public HomeController(IEmployeeRepository employeeRepository,
            IHostingEnvironment   hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
           
        }
        
        public ViewResult Index()
        {
            return View();
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
        public ViewResult Employees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        [HttpGet]
        public  IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public   IActionResult CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = _employeeRepository.AddEmployee(employee);
                //return RedirectToAction("Employee", new { id = newEmployee.Id });
            }
            return View();
        }
       
        [HttpPost]
        public IActionResult CreateNewEmployee(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileNme = ProcessUploadedFile(model);
                var newEmployee = new Employee
                {
                    FirstName = model.FirstName,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileNme
                };
                _employeeRepository.AddEmployee(newEmployee);
                return RedirectToAction("Employee", new { id = newEmployee.Id });
            }
            return View();
        }
              
        public ViewResult  Edit(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            var employeeViewModel = new EditEmployee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeViewModel);
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
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath =  Path.Combine(hostingEnvironment.WebRootPath, "Images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }
               
                return RedirectToAction("Employees");
            }
            return View();
        }
        public ViewResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
            
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Employees","Home");
                }
                foreach (var  error in  result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }

            }
            return View(model);
        }
        public IActionResult  LogIn()
        {
            return View();
        }


        // Because they have inheritance
        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileNme = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                uniqueFileNme = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNme);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(stream);
                }
               
            }

            return uniqueFileNme;
        }
       
    }
}
