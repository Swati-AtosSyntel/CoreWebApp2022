using CoreWebApp2022.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp2022.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View(employeeRepository.GetEmployees());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.AddEmployee(e);
                return RedirectToAction("Index");
            }
            return View(e);
        }
    }
}
