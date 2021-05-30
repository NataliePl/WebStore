using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> __Employees = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 27 },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", Age = 31 },
            new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", Age = 18 },
        };


        private readonly IConfiguration _Configuration;

        public HomeController(IConfiguration Configuration) { _Configuration = Configuration; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SecondAction()
        {
            return Content(_Configuration["Greetings"]);
        }

        public IActionResult Employees()
        {
            return View(__Employees);
        }

        public IActionResult EmployeeDetails(int id)
        {

            var employee = __Employees.FirstOrDefault(employee => employee.Id == id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        public IActionResult EmployeeEdit(int id)
        {

            var employee = __Employees.FirstOrDefault(employee => employee.Id == id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }
        //попытка реализовать изменение сотрудника
        //public IActionResult EmployeeChange(int id)
        //{

        //    //var employee = __Employees.FirstOrDefault(employee => employee.Id == id);

        //    //if (employee == null)
        //    //    return NotFound();
        //    __Employees.RemoveAt(1);
        //    return Content("Изменения не изменены");
        //}
        public IActionResult Blog() => View();

        public IActionResult BlogSingle() => View();

        public IActionResult Cart() => View();

        public IActionResult Checkout() => View();

        public IActionResult ContactUs() => View();

        public IActionResult Login() => View();

        public IActionResult ProductDetails() => View();

        public IActionResult Shop() => View();

        public IActionResult NotFound() => View();
    }
}
