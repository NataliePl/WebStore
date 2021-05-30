﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult EmployeeDetailes(int id)
        {

            var employee = __Employees.FirstOrDefault(employee => employee.Id == id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        public IActionResult Blog() => View();


    }
}
