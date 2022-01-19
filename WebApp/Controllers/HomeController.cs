using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService studentService;

        public HomeController(ILogger<HomeController> logger, IStudentService studentService)
        {
            _logger = logger;
            this.studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> students = await studentService.GetStudents();
            return View();
        }

        public IActionResult AddStudent(string name, int age)
        {
            Student student = new Student();
            student.Name = name;
            student.Age = age;

            studentService.AddStudents(student);
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
